using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
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
        }
    }
}
