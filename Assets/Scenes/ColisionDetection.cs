using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public AudioSource DeathSound; // Son de dégât
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerRespawn respawn = collision.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
        }

        if (collision.CompareTag("Decor") && gameObject.CompareTag("Ennemie"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Ennemie") && collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player is dead");
            DeathSound.Play();  // Joue le son de mort
        }
    }
}
