using UnityEngine;

public class AIRunner : SimRunner
{
    private Simulator _simulator;
    public AIRunner(Simulator simulator)
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
        UI.Main.SetAIVisibility(!UI.Main.SimulatorActive());
    }

    public void RunBlackScreen()
    {
        UI.Main.StartBlackScreen();
    }
}
