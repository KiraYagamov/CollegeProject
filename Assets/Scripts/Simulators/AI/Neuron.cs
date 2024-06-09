using UnityEngine;
using UnityEngine.UI;

public class Neuron : MonoBehaviour
{
    [SerializeField] private Text neuronText;
    private float value;

    public void SetValue(float value)
    {
        this.value = value;
        neuronText.text = value.ToString();
    }

    public float GetValue()
    {
        return value;
    }
}
