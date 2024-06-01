﻿using UnityEngine;

namespace Simulators
{
    public class DoorRunner : SimRunner
    {
        private Simulator _simulator;
        public DoorRunner(Simulator simulator)
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
            UI.Main.SetDoorVisibility(!UI.Main.SimulatorActive());
        }

        public void RunBlackScreen()
        {
            UI.Main.StartBlackScreen();
        }
    }
}