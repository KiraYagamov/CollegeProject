using UnityEngine;
using UnityEngine.SceneManagement;

namespace Simulators
{
    public class PhysicsRunner : SimRunner
    {
        public void RunTask()
        {
            SceneManager.LoadScene("PhysicsSimulator");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void RunBlackScreen()
        {
            UI.Main.StartBlackScreen();
        }
    }
}