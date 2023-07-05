using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool Draggable = false;

    public string CardType;
    private BoxCollider2D cardbc;

    public GameObject bucketA;
    public GameObject bucketB;

    CardSortManager cardSortManager;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        bucketA = GameObject.Find("Basket White");
        bucketB = GameObject.Find("Basket Black");
        cardbc = GetComponent<BoxCollider2D>();
        cardSortManager = GameObject.Find("CardManager").GetComponent<CardSortManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag() {

        if (Draggable == true)
        {
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }

    }

    private void OnMouseUp()
    {
        if (cardbc.IsTouching(bucketA.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touched");
            if (CardType == "White")
            {
                Debug.Log("Correct");
                cardSortManager.cardlist.RemoveAt(0);
                Destroy(gameObject);


            }
            else
            {
                Debug.Log("Wrong");
            }
        }
        else if (cardbc.IsTouching(bucketB.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touched");
            if (CardType == "Black")
            {
                Debug.Log("Correct");
                cardSortManager.cardlist.RemoveAt(0);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }


}
