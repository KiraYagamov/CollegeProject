using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public void ToOffice()
    {
        SceneManager.LoadScene(0);
    }

    public void ToGym()
    {
        SceneManager.LoadScene(1);
    }
}
