using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause;
    public static bool estEnPause = false;

    [Header("Références")]
    public PlayerMovement playerMovement; // 👈 à assigner dans l'inspecteur

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
        Time.timeScale = 1f;
        estEnPause = false;

        // ✅ On réactive les inputs du joueur
        if (playerMovement != null)
        {
            playerMovement.EnableInputs();
        }

        Debug.Log("🎮 Reprise du jeu");
    }

    public void PauseGame()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        estEnPause = true;

        // ✅ On désactive les inputs du joueur
        if (playerMovement != null)
        {
            playerMovement.DisableInputs();
        }

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
