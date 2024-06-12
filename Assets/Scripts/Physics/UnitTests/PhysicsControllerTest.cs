using UnityEngine;

namespace Physics.UnitTests
{
    public class PhysicsControllerTest
    {
        public PhysicsController Physics;

        public void TestAllRight()
        {
            //All connected - true | else - false
            Debug.Log(Physics.AllRight());
        }
    }
}