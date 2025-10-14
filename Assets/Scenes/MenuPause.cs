using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause;
    public static bool estEnPause = false;

    void Start()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f; // Assure que le jeu démarre à vitesse normale
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estEnPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f; // Reprendre le temps
        estEnPause = false;
        Debug.Log("🎮 Reprise du jeu");
    }

    public void PauseGame()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f; // Mettre le temps en pause
        estEnPause = true;
        Debug.Log("⏸ Jeu en pause");
    }

    public void QuitterLeJeu()
    {
        Debug.Log("Le jeu va se fermer...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RecommencerLeNiveau()
    {
        Time.timeScale = 1f;
        estEnPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
