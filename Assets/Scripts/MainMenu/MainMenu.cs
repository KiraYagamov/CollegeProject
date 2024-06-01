using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("OfficeScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
