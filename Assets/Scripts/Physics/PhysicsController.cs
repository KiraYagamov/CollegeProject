using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public DrawLine currentDrawing;
    private Camera _camera;
    [SerializeField] private Sprite onTorch, offTorch;
    [SerializeField] private SpriteRenderer torch;
    [SerializeField] private DrawLine[] drawLines;
    [SerializeField] private Switcher switcher;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (hit.transform.TryGetComponent(out Switcher sw))
                {
                    sw.state = !sw.state;
                    if (sw.state) sw.SpriteRenderer.sprite = sw.on;
                    else sw.SpriteRenderer.sprite = sw.off;
                }
                
                if (!currentDrawing)
                {
                    if (hit.transform.TryGetComponent(out DrawLine line))
                    {
                        currentDrawing = line;
                        line.SetPos1();
                    }
                }
                else
                {
                    if (hit.transform.TryGetComponent(out SecondPos pos))
                    {
                        currentDrawing.SetPos2(pos.pos);
                        currentDrawing.connectedPos = pos;
                        currentDrawing = null;
                    }
                }
            }
        }

        if (currentDrawing)
        {
            Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            currentDrawing.lineRenderer.SetPosition(1, pos);
        }

        torch.sprite = AllRight() ? onTorch : offTorch;
    }

    private bool AllRight()
    {
        bool right = true;
        if (!switcher.state) return false;
        foreach (var drawLine in drawLines)
        {
            if (drawLine.connectedPos)
            {
                if (drawLine.connectedPos != drawLine.needToConnect)
                {
                    right = false;
                    break;
                }
            }
            else
            {
                right = false;
                break;
            }
        }

        return right;
    }
}
