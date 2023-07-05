using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCreamActive : MonoBehaviour
{

    CharMove player;
    public GameObject MrCream;
    
    public bool Coridor = true;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();

        

        
    }

    // Update is called once per frame
    void Update()
    {
        var quest = player.questManager;

        if (quest.questManager[4].isComplete && Coridor)
        {
            MrCream.SetActive(true);
        }

        if (quest.questManager[4].isComplete && !Coridor)
        {
            MrCream.SetActive(false);
        }
    }
}
