using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform rayOrigin;
    public AudioSource BossDeadSound;

    [Header("Prefab du boss mort")]
    public GameObject deadBossPrefab;

    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.up, 0.1f);

        if (hit && hit.collider.CompareTag("Player"))
        {
            Debug.Log("☠️ Boss éliminé");

            // Joue le son de mort
            if (BossDeadSound != null && BossDeadSound.clip != null)
            {
                AudioSource.PlayClipAtPoint(BossDeadSound.clip, transform.position);
            }

            // Instancier le prefab de mort 0.5f plus bas que la position actuelle
            if (deadBossPrefab != null)
            {
                Vector3 spawnPos = transform.position + Vector3.down * 0.5f;
                Instantiate(deadBossPrefab, spawnPos, transform.rotation);
            }

            // Détruire le boss vivant
            Destroy(gameObject);

            isDead = true;
        }
    }
}
