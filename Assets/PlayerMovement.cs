using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    public float sprintSpeed = 10f;

    public Transform playerSprite;

    public AudioSource WalkSound;

    public AudioSource JumpSound;
    
    
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        Gravity();
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;

        // Flip sprite based on movement direction
        if (horizontalMovement != 0 && isGrounded())
        {
            playerSprite.localScale = new Vector3(Mathf.Sign(horizontalMovement), 1, 1);

            if (!WalkSound.isPlaying)
            {
            WalkSound.Play();
            }
        }
        else
        {
            if (WalkSound.isPlaying)
            {
            WalkSound.Pause();
            }
        }

        if (Keyboard.current.leftShiftKey.isPressed)
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = 5f;
        }
    }

    private void Gravity()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }




    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded()) {
            if (context.performed)
            {
                JumpSound.Play();
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }
        return false;
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
