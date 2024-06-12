using UnityEngine;

namespace DefaultNamespace.UnitTests
{
    public class SysAdminControllerTest
    {
        public SysAdminController SysAdmin;

        public void CheckWinTest()
        {
            // Win - true | Lose - false
            Debug.Log(SysAdmin.CheckWin());
        }
    }
}