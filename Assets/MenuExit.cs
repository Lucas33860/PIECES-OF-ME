using UnityEngine;

public class MenuExit : MonoBehaviour
{
    // Appelé quand on clique sur le bouton "Exit"
    public void QuitterLeJeu()
    {
        Debug.Log("Le jeu va se fermer...");

        // Si on est dans l’éditeur Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si on est dans le build (jeu compilé)
        Application.Quit();
#endif
    }

        private void OnTriggerEnter(Collider other)
    {
        // Optionnel : vérifier que c’est bien le joueur
        if (other.CompareTag("Player"))
        {
            QuitterLeJeu();
        }
    }
}