using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
