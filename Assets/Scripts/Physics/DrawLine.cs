using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector2 _pos1;
    public Vector2 _pos2;
    public SecondPos connectedPos;
    public SecondPos needToConnect;

    public void SetPos1()
    {
        lineRenderer.positionCount = 2;
        _pos1 = transform.position;
        lineRenderer.SetPosition(0, _pos1);
        lineRenderer.SetPosition(1, _pos1);
        connectedPos = null;
    }

    public void SetPos2(Vector2 pos)
    {
        _pos2 = pos;
        lineRenderer.SetPosition(1, _pos2);
    }
}
