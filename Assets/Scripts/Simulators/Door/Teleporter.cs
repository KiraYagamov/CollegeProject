using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public void ToOffice()
    {
        UI.Main.simDoing = () =>
        {
            SceneManager.LoadScene("OfficeScene");
        };
        UI.Main.StartBlackScreen();
    }

    public void ToGym()
    {
        UI.Main.simDoing = () =>
        {
            SceneManager.LoadScene("GymScene");
        };
        UI.Main.StartBlackScreen();
    }
}
