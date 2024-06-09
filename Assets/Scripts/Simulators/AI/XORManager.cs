using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XORManager : MonoBehaviour
{
    [SerializeField] private int[] layers;
    [SerializeField] private GameObject neuronPrefab;
    [SerializeField] private GameObject layerPrefab;
    [SerializeField] private Transform neuronsField;
    public int populationSize;

    private List<Neuron>[] neurons;

    [Range(0.0001f, 1f)] public float MutationChance = 0.01f;

    [Range(0f, 1f)] public float MutationStrength = 0.5f;

    [Range(0.1f, 10f)] public float Gamespeed = 1f;
    public List<NeuralNetwork> networks;
    private List<XORBot> bots;

    private float[] inputs;
    [SerializeField] private GameObject prefab;
    public float timeframe;
    private bool stop = true;
    [SerializeField] private Text learnBtnText;

    private void Start()
    {
        neurons = new List<Neuron>[layers.Length];
        GenerateField();
        if (populationSize % 2 != 0)
            populationSize = 50;
        stop = true;
        InitNetworks();
        CreateBots();
        InvokeRepeating("CreateBots", 0.1f, timeframe);
    }
    
    public void InitNetworks()
    {
        networks = new List<NeuralNetwork>();
        for (int i = 0; i < populationSize; i++)
        {
            NeuralNetwork net = new NeuralNetwork(layers);
            networks.Add(net);
        }
    }

    private void GenerateField()
    {
        for (int layer = 0; layer < layers.Length; layer++)
        {
            Transform currentLayer = Instantiate(layerPrefab, neuronsField).transform;
            neurons[layer] = new List<Neuron>();
            for (int neuron = 0; neuron < layers[layer]; neuron++)
            {
                Neuron currentNeuron = Instantiate(neuronPrefab, currentLayer).GetComponent<Neuron>();
                neurons[layer].Add(currentNeuron);
                currentNeuron.SetValue(0);
                if (layer == 0)
                {
                    Button neuronBtn = currentNeuron.GetComponent<Button>();
                    neuronBtn.onClick.AddListener(() =>
                    {
                        NeuralNetwork network = networks[populationSize - 1];
                        if (currentNeuron.GetValue() == 0)
                            currentNeuron.SetValue(1);
                        
                        else
                            currentNeuron.SetValue(0);
                        inputs = new float[3];
                        for (int i = 0; i < 3; i++)
                        {
                            inputs[i] = neurons[0][i].GetValue();
                        }

                        float[] output = network.FeedForward(inputs);
                        SetNeurons();
                    });
                }
            }
        }
    }

    private void Update()
    {
        if (!stop) SetNeurons();
    }

    public void Learn()
    {
        stop = !stop;
        if (stop)
            learnBtnText.text = "Обучать";
        else
            learnBtnText.text = "Стоп";
    }

    public void CreateBots()
    {
        if (!stop)
        {
            Time.timeScale = Gamespeed;
            if (bots != null)
            {
                for (int i = 0; i < bots.Count; i++)
                {
                    Destroy(bots[i].gameObject);
                }

                SortNetworks();
            }

            bots = new List<XORBot>();
            for (int i = 0; i < populationSize; i++)
            {
                XORBot bot = Instantiate(prefab, new Vector2(0, 0), new Quaternion(0, 0, 1, 0)).GetComponent<XORBot>();
                bot.network = networks[i];
                bots.Add(bot);
            }
        }
    }
    public void SortNetworks()
    {
        for (int i = 0; i < populationSize; i++)
        {
            bots[i].UpdateFitness();
        }
        networks.Sort();
        for (int i = 0; i < populationSize / 2; i++)
        {
            networks[i] = networks[populationSize - 1].copy(new NeuralNetwork(layers));
            networks[i].Mutate((int)(1/MutationChance), MutationStrength);
        }
    }
    private void SetNeurons()
    {
        float[][] currentNeurons = networks[populationSize-1].GetNeurons();
        for (int layer = 0; layer < currentNeurons.Length; layer++)
        {
            for (int neuron = 0; neuron < currentNeurons[layer].Length; neuron++)
            {
                float value = currentNeurons[layer][neuron];
                if (layer == currentNeurons.Length - 1) value = Math.Abs(value);
                neurons[layer][neuron].SetValue(value);
            }
        }
    }
}
