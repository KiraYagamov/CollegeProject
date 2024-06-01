using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PythonSimulator : MonoBehaviour
{
    [SerializeField] private InputField pythonCode;
    [SerializeField] private Text result;
    private string[] rightAnswers = {"print(a + b)", "print(a+b)"};

    public void CheckAnswer()
    {
        string[] lines = pythonCode.text.Split("\n");
        List<string> linesList = new List<string>();
        foreach (var line in lines)
        {
            if (line != String.Empty) linesList.Add(line);
        }
        if (linesList.Count < 3)
        {
            result.color = Color.red;
            result.text = "Ошибка!";
            return;
        }
        int a = 0;
        int b = 0;
        bool[] hasVars = {false, false};
        bool error = false;
        string[] line1 = linesList[0].Trim().Split(" ");
        string[] line2 = linesList[1].Trim().Split(" ");
        string line3 = linesList[2].Trim();
        if (line1[1] == "=")
        {
            if (line1[0] == "a")
            {
                a = Int32.Parse(line1[2]);
                hasVars[0] = true;
            }
            else if (line1[0] == "b")
            {
                b = Int32.Parse(line1[2]);
                hasVars[1] = true;
            }
            else error = true;
        }
        if (line2[1] == "=")
        {
            if (line2[0] == "a")
            {
                a = Int32.Parse(line2[2]);
                hasVars[0] = true;
            }
            else if (line2[0] == "b")
            {
                b = Int32.Parse(line2[2]);
                hasVars[1] = true;
            }
            else error = true;
        }

        bool allVars = true;
        foreach (var variable in hasVars)
        {
            if (!variable) allVars = false;
        }
        if (Contains(line3) && !error && allVars)
        {
            result.color = Color.green;
            result.text = $"Вывод: {a + b}";
        }
        else
        {
            result.color = Color.red;
            result.text = "Ошибка!";
        }
    }

    private bool Contains(string data)
    {
        foreach (var answer in rightAnswers)
        {
            if (answer == data) return true;
        }

        return false;
    }
    
}
