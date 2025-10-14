using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform rayOrigin;
    public AudioSource BossDeadSound;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.up, 0.1f);

        if (hit)
        {
            Debug.Log("boss détecté");
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Le boss a touché le joueur avec un rayon !");

                if (BossDeadSound != null && BossDeadSound.clip != null)
                {
                    AudioSource.PlayClipAtPoint(BossDeadSound.clip, transform.position);
                }

                // Destroy the boss after playing the sound
                Destroy(gameObject);
            }
        }
    }
}
