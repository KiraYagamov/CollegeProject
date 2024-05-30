using UnityEngine;

public class RaycastForSimulators : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float rayDistance = 5f;
    [SerializeField] private Simulator currentSimulator;

    private void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(ray, out var hitInfo))
        {
            Simulator sim = null;
            if (Vector3.Distance(hitInfo.point, camera.transform.position) <= rayDistance)
            {
                if (hitInfo.transform.gameObject.TryGetComponent(out Simulator simulator)) sim = simulator;
            }
            SetSimulator(sim);
        }
    }

    private void SetSimulator(Simulator simulator)
    {
        if (currentSimulator != simulator)
        {
            currentSimulator = simulator;
            if (currentSimulator != null) UI.Main.SetSimulatorText(currentSimulator.simulatorText);
            else UI.Main.SetSimulatorText(string.Empty);
        }
    }

    public Simulator GetSimulator()
    {
        return currentSimulator;
    }
}
