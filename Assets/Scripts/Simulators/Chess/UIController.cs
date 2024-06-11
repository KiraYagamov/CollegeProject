using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void Leave()
    {
        animator.SetTrigger("BlackscreenBack");
    }

    public void LoadGym()
    {
        SceneManager.LoadScene("GymScene");
    }

    public void LoadSysAdmin()
    {
        SceneManager.LoadScene("SysAdminOffice");
    }

    public void LeaveFromSysAdmin()
    {
        animator.SetTrigger("SysAdminLeave");
    }
}
