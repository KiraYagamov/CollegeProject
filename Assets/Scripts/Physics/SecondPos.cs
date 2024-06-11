using UnityEngine;

public class SecondPos : MonoBehaviour
{
    public Vector2 pos;

    private void Start()
    {
        pos = transform.position;
    }
}
