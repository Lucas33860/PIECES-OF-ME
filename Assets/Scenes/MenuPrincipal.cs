using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("Niveau 1"); // nom de ta scène de jeu
    }

    public void Quitter()
    {
        Debug.Log("Le jeu est quitté !");
        Application.Quit(); // ne fonctionne qu'après build
    }
}

