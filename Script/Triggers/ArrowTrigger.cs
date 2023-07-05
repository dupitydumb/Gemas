using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    CharMove player;
    QuestManager quest;
    // Start is called before the first frame update
    void Start()
    {
        quest = GetComponent<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (quest.questManager[4].isComplete)
        {
            Destroy(gameObject);
        }

    }
}
