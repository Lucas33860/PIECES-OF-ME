using UnityEngine;

public class FoundLegs : MonoBehaviour
{
    public GameObject newPlayerPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jambes"))
        {
            // Détruit l'image au sol (l'objet touché)
            Destroy(other.gameObject);

            // Remplace le joueur par un nouveau prefab
            Vector3 position = transform.position;
            Destroy(gameObject);
            if (newPlayerPrefab != null)
            {
                // Utilise Quaternion.identity pour remettre le sprite droit
                Instantiate(newPlayerPrefab, position, Quaternion.identity);
            }
        }
    }
}
