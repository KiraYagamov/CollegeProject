using Simulators;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public string simulatorName;
    private SimRunner _simRunner;
    private bool _isSimulatorOpened;
    public string simulatorText;

    private void Start()
    {
        if (simulatorName == "Python")
        {
            _simRunner = new PythonSimulatorRunner(this);
        }
        else if (simulatorName == "Door")
        {
            _simRunner = new DoorRunner(this);
        }
        else if (simulatorName == "Chess")
        {
            _simRunner = new ChessRunner();
        }
    }

    public SimRunner GetRunner()
    {
        return _simRunner;
    }

    public bool IsOpened()
    {
        return _isSimulatorOpened;
    }

    public void SetOpened(bool isOpened)
    {
        _isSimulatorOpened = isOpened;
    }
}
