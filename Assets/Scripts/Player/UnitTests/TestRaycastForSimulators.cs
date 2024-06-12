using UnityEngine;

namespace Player.UnitTests
{
    public class TestRaycastForSimulators
    {
        public RaycastForSimulators Raycast;

        public void TestSetSimulator_Test()
        {
            Simulator simulator = new Simulator();
            simulator.simulatorName = "Test";
            Raycast.SetSimulator(simulator);
            Debug.Log(Raycast.GetSimulator().simulatorName);
        }
    }
}