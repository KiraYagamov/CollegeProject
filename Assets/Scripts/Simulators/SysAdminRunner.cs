using UnityEngine;
using UnityEngine.SceneManagement;

namespace Simulators
{
    public class SysAdminRunner : SimRunner
    {
        public void RunTask()
        {
            SceneManager.LoadScene("SysAdmin");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void RunBlackScreen()
        {
            UI.Main.StartBlackScreen();
        }
    }
}