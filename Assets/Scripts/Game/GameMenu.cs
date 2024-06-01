using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;
    public static GameMenu Main;
    public bool menuOpened = false;

    private void Start()
    {
        Main = this;
    }

    public void Continue()
    {
        menuObject.SetActive(false);
        menuOpened = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(true);
            menuOpened = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
