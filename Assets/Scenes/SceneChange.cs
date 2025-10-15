using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinNiv1"))
        {
            SceneManager.LoadScene("Niveau 2");
        }
        if (other.CompareTag("FinNiv2"))
        {
            SceneManager.LoadScene("Niveau 3");
        }
    }
}
