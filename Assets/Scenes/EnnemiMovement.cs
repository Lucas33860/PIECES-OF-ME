using UnityEngine;

public class EnnemiMovement : MonoBehaviour
{
    public float speed = 5f;
    public float leftLimit = -150f;
    public float rightLimit = 150f;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HorizontalMovement();
        FlipSprite();
    }

    void HorizontalMovement()
    {
        Vector3 movement = speed * Time.deltaTime * new Vector3(direction, 0f, 0f);
        transform.Translate(movement);

        if (transform.position.x >= rightLimit)
            direction = -1;
        else if (transform.position.x <= leftLimit)
            direction = 1;
    }

    void FlipSprite()
    {
        if (spriteRenderer != null)
            spriteRenderer.flipX = direction == -1;
    }
}
