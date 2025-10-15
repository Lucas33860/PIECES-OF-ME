using UnityEngine;

public class FoundArms : MonoBehaviour
{
    public GameObject newPlayerPrefab;
    public float spawnYOffset = 0.5f; // Ajuste cette valeur selon tes besoins

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bras"))
        {
            // Détruit tous les objets avec le tag "Bras"
            GameObject[] brasObjects = GameObject.FindGameObjectsWithTag("Bras");
            foreach (GameObject bras in brasObjects)
            {
                Destroy(bras);
            }

            // Remplace le joueur par un nouveau prefab, légèrement au-dessus du sol
            Vector3 position = transform.position;
            position.y += spawnYOffset;
            Destroy(gameObject);
            if (newPlayerPrefab != null)
            {
                Instantiate(newPlayerPrefab, position, Quaternion.identity);
            }
        }
    }
}
