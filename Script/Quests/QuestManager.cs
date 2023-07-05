using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestManager", menuName = "ScriptableObjects/QuestManager")]
public class QuestManager : ScriptableObject
{

    [System.Serializable]
    public struct QuestManagers
    {
        public string questName;
        public bool isComplete;
    }
    [SerializeField]
    public List<QuestManagers> questManager = new List<QuestManagers>();

    public int CurrentQuest = 0;



    public void Quest1()
    {
        var questManager1 = questManager[0];
        questManager1.isComplete = true;
        questManager[0] = questManager1;
        Debug.Log(questManager1);

        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();

        saveManager.SaveGame();
    }

    public void Quest2()
    {
        var questManager1 = questManager[1];
        questManager1.isComplete = true;
        questManager[1] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest3()
    {
        var questManager1 = questManager[2];
        questManager1.isComplete = true;
        questManager[2] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest4()
    {
        var questManager1 = questManager[3];
        questManager1.isComplete = true;
        questManager[3] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest5()
    {
        var questManager1 = questManager[4];
        questManager1.isComplete = true;
        questManager[4] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest6()
    {
        var questManager1 = questManager[5];
        questManager1.isComplete = true;
        questManager[5] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest7()
    {
        var questManager1 = questManager[6];
        questManager1.isComplete = true;
        questManager[6] = questManager1;
        Debug.Log(questManager1);

        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest8()
    {
        var questManager1 = questManager[7];
        questManager1.isComplete = true;
        questManager[7] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest9()
    {
        var questManager1 = questManager[8];
        questManager1.isComplete = true;
        questManager[8] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }

    public void Quest10()
    {
        var questManager1 = questManager[9];
        questManager1.isComplete = true;
        questManager[9] = questManager1;
        Debug.Log(questManager1);
        var saveManager = GameObject.FindWithTag("Save System").GetComponent<Save>();
        saveManager.SaveGame();
    }
    // Start is called before the first frame update
}
