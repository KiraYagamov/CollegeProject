using UnityEngine;

namespace Physics.UnitTests
{
    public class DrawLineTest
    {
        public DrawLine Draw;
        public void TestSetPos1_Setting2PosIn1Coord()
        {
            Draw.SetPos1();
        }
        public void TestSetPos2_Setting2PosIntoCoord_33()
        {
            Draw.SetPos2(new Vector2(2, 2));
        }
    }
}