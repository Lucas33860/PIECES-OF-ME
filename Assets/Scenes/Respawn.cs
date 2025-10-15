using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [HideInInspector] public Vector3 respawnPoint;  // Position de respawn
    public float deathY = -10f;                     // Limite sous la map

    private Rigidbody2D rb;

    void Start()
    {
        respawnPoint = transform.position; // Point de départ
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Le joueur a touché le boss !");
            Respawn();
        }
    }

    void Update()
    {
        // Si le joueur tombe trop bas
        if (transform.position.y < deathY)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint;

        // Reset des vitesses si Rigidbody2D
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
}
