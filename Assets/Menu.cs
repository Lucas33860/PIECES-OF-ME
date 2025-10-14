using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Tooltip("Nom de la scène à charger")]
    public string nomDeScene;

    // Appelé quand on veut changer de scène (par un bouton ou un trigger)
    public void AllerAuNiveau()
    {
        SceneManager.LoadScene(nomDeScene);
    }

        // Quand un autre objet entre dans le collider (avec isTrigger = true)
    private void OnTriggerEnter(Collider other)
    {
        // Optionnel : vérifier que c’est bien le joueur
        if (other.CompareTag("Player"))
        {
            AllerAuNiveau();
        }
    }
}
