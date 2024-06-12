using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class XORBot : MonoBehaviour
{
    private float[] inputs = new float[2];
    public NeuralNetwork network;
    private float points;

    public void UpdateFitness()
    {
        network.fitness = points;
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    inputs = new float[3];
                    inputs[0] = Random.Range(0, 2);
                    inputs[1] = Random.Range(0, 2);
                    inputs[2] = Random.Range(0, 2);
                    float[] outputs = network.FeedForward(inputs);
                    int xorValue = (int) inputs[0] ^ (int) inputs[1] ^ (int) inputs[2];
                    if (Math.Abs(xorValue - Math.Abs(outputs[0])) >= 0.5f)
                    {
                        points -= Math.Abs(xorValue - Math.Abs(outputs[0]));
                    }
                    else
                    {
                        points += 1 - Math.Abs(xorValue - Math.Abs(outputs[0]));
                    }
                }
            }
        }
    }
}
