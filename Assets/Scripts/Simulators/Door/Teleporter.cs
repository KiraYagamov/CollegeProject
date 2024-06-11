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

    public void ToAI()
    {
        UI.Main.simDoing = () =>
        {
            SceneManager.LoadScene("Office2");
        };
        UI.Main.StartBlackScreen();
    }

    public void ToPhysics()
    {
        UI.Main.simDoing = () =>
        {
            SceneManager.LoadScene("Physics");
        };
        UI.Main.StartBlackScreen();
    }

    public void ToSysAdmin()
    {
        UI.Main.simDoing = () =>
        {
            SceneManager.LoadScene("SysAdminOffice");
        };
        UI.Main.StartBlackScreen();
    }
}
