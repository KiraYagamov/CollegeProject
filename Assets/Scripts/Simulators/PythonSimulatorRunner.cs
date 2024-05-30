using UnityEngine;

namespace Simulators
{
    public class PythonSimulatorRunner :  SimRunner
    {
        private Simulator _simulator;
        public PythonSimulatorRunner(Simulator simulator)
        {
            _simulator = simulator;
        }
        public void RunTask()
        {
            _simulator.SetOpened(!UI.Main.SimulatorActive());
            if (UI.Main.SimulatorActive())
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            UI.Main.SetPythonSimulatorVisibility(!UI.Main.SimulatorActive());
        }

        public void RunBlackScreen()
        {
            UI.Main.StartBlackScreen();
        }
    }
}