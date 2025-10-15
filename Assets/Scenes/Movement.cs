using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5f;          // Vitesse max normale
    public float sprintSpeed = 10f;      // Vitesse max quand on sprinte
    public float acceleration = 10f;     // Accélération (plus grand = plus rapide)
    public float deceleration = 15f;     // Décélération (plus grand = freine plus vite)

    private float currentSpeed = 0f;
    private float targetSpeed = 0f;

    public AudioSource audioSource;

    public AudioSource pushSound;

    private IEnumerator RotateOverTime(float angle, float duration)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, 0f, angle);
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endRotation;
    }

void Update()
{
    // ✅ Si le jeu est en pause, on bloque tout
    if (MenuPause.estEnPause)
    {
        // On stoppe les sons de marche pour éviter qu'ils continuent en fond
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        currentSpeed = 0f; // empêche le perso de continuer à glisser
        return;
    }

    float moveInput = 0f;
    float baseRotationSpeed = 360f; // Vitesse de rotation de base
    float rotationSpeed = baseRotationSpeed;

    if (Input.GetKey(KeyCode.LeftShift))
    {
        rotationSpeed *= 2f;
    }

    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
        moveInput = -1f;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
        moveInput = 1f;
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    else
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boite"))
        {
            if (pushSound != null && !pushSound.isPlaying)
            {
                pushSound.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boite"))
        {
            if (pushSound != null && pushSound.isPlaying)
            {
                pushSound.Stop();
            }
        }
    }
}
