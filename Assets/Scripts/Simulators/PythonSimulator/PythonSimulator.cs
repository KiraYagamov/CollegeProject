using UnityEngine;
using UnityEngine.UI;

public class PythonSimulator : MonoBehaviour
{
    [SerializeField] private InputField pythonCode;
    [SerializeField] private Text result;
    private string[] rightAnswers = {"print(a + b)", "print(a+b)"};

    public void CheckAnswer()
    {
        if (Contains(pythonCode.text.Trim()))
        {
            result.color = Color.green;
            result.text = "Верно!";
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
