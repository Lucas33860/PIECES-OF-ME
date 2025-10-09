using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5f;          // Vitesse max normale
    public float sprintSpeed = 10f;      // Vitesse max quand on sprinte
    public float acceleration = 10f;     // Accélération (plus grand = plus rapide)
    public float deceleration = 15f;     // Décélération (plus grand = freine plus vite)

    private float currentSpeed = 0f;
    private float targetSpeed = 0f;

    void Update()
    {
        float moveInput = 0f;

       
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

       
        float maxCurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : maxSpeed;

       
        targetSpeed = moveInput * maxCurrentSpeed;

        if (Mathf.Abs(targetSpeed) > 0.01f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        }
        else
        {
    
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        transform.position += new Vector3(currentSpeed * Time.deltaTime, 0f, 0f);
    }
}
