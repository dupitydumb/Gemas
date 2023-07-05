using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSortManager : MonoBehaviour
{
    public List<GameObject> cardlist;
    

    public GameObject bucketA;
    public GameObject bucketB;

    BoxCollider2D cardbc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cardlist[0].GetComponent<DragAndDrop>().Draggable = true;
        cardlist[0].GetComponent<BoxCollider2D>().enabled = true;


    }

    void CardUpdated()
    {
        cardlist[0].GetComponent<DragAndDrop>().Draggable = true;
    }


}
