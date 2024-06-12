using UnityEngine;

public class PythonSimulatorTest
{
    public PythonSimulator Python;

    public void TestContains_True()
    {
        Debug.Log(Python.Contains("print(a + b)"));
    }
}