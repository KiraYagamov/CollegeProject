using UnityEngine;

public class QuestsController : MonoBehaviour
{
    [SerializeField] private GameObject quest1, quest2, quest3, quest4, quest5;
    private void Update()
    {
        if (QuestManager.Quest1 > 0) quest1.SetActive(false);
        if (QuestManager.Quest2 > 0) quest2.SetActive(false);
        if (QuestManager.Quest3 > 0) quest3.SetActive(false);
        if (QuestManager.Quest4 > 0) quest4.SetActive(false);
        if (QuestManager.Quest5 > 0) quest5.SetActive(false);
    }
}
