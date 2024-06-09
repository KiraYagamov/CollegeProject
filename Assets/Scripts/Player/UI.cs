using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Main;
    [SerializeField] private Text simulatorText;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] simulators;
    public Action simDoing;

    private void Start()
    {
        Main = this;
    }

    public void SetSimulatorText(string text)
    {
        simulatorText.text = text;
    }

    public void StartBlackScreen()
    {
        animator.SetTrigger("BlackScreen");
    }

    public void SetPythonSimulatorVisibility(bool visibility)
    {
        foreach (var simulator in simulators)
        {
            if (simulator.name == "Python") simulator.gameObject.SetActive(visibility);
        }
    }
    public void SetDoorVisibility(bool visibility)
    {
        foreach (var simulator in simulators)
        {
            if (simulator.name == "Door") simulator.gameObject.SetActive(visibility);
        }
    }

    public void SetAIVisibility(bool visibility)
    {
        foreach (var simulator in simulators)
        {
            if (simulator.name == "AI") simulator.gameObject.SetActive(visibility);
        }
    }
    public bool SimulatorActive()
    {
        bool active = false;
        foreach (var simulator in simulators)
        {
            if (simulator.gameObject.activeSelf) active = true;
        }
        return active;
    }

    public void DoAction()
    {
        simDoing.Invoke();
    }
}
