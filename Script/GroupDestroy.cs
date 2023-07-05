using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDestroy : MonoBehaviour
{
    
    CardSortManager cardSortManager;

    // Start is called before the first frame update
    void Start()
    {
        cardSortManager = GameObject.Find("CardManager").GetComponent<CardSortManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardSortManager.cardlist.Count == 0)
        {
            Destroy(gameObject);
        }

    }
}
