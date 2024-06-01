using UnityEngine;
using UnityEngine.SceneManagement;

public class ChessRunner : SimRunner
{
    public void RunTask()
    {
        SceneManager.LoadScene("ChessScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RunBlackScreen()
    {
        UI.Main.StartBlackScreen();
    }
}
