using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public QuestManager questmanager;

    bool quest1;

    // Start is called before the first frame update
    void Start()
    {
        quest1 = questmanager.questManager[0].isComplete;

        // Get ScriptableObject
        var quest = questmanager;
        // Debug.Log(quest.questManager[0].questName);
        if (quest.questManager[0].isComplete)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check if player collide with this object
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            questmanager.Quest1();
            Destroy(gameObject);
        }
    }
}
