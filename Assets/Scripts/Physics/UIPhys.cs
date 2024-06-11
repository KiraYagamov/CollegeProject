using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPhys : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void Leave()
    {
        animator.SetTrigger("BlackscreenBackPhys");
    }

    public void LoadPhys()
    {
        SceneManager.LoadScene("Physics");
    }
}
