using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform rayOrigin; 
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.up, 0.1f);

        if (hit)
        {
            Debug.Log("boss detecté");
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Le boss a touché le joueur avec un rayon !");
                Destroy(gameObject);
            }
        }
    }
}
