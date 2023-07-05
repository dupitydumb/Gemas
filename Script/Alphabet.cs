using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alphabet : MonoBehaviour
{
    public string alphabet;
    public GameObject Req;
    WordReq wordreq;
    GameObject wordreqobj;


    public void Start()
    {
        Req = GameObject.FindGameObjectWithTag("Word");
        wordreq = Req.GetComponent<WordReq>();
        wordreq.wordsactive[wordreq.currentword].transform.GetChild(2).gameObject.SetActive(true);

    }


    public void Clicked()
    {
        wordreqobj = wordreq.wordsneeded[wordreq.currentword];
        if (wordreqobj.GetComponent<Alphabet>().alphabet == alphabet)
        {
            wordreq.wordsactive[wordreq.currentword].SetActive(true);
            wordreq.wordsactive[wordreq.currentword].transform.GetChild(0).GetComponent<Image>().color = Color.green;
            Debug.Log("Correct");
            wordreq.wordsactive[wordreq.currentword].transform.GetChild(2).gameObject.SetActive(false);
            wordreq.currentword++;
            UpdateFrame();
            wordreq.DestroyWord();
            wordreq.SpawnWord();
            wordreq.SetSiblingIndex();
        }
        else
        {
            Debug.Log("Wrong");
            Destroy(gameObject);
        }

    }



    public void UpdateFrame()
    {
        wordreq.wordsactive[wordreq.currentword].transform.GetChild(2).gameObject.SetActive(true);
    }

    public void ResetColor()
    {
        wordreq.wordsactive[wordreq.currentword].transform.GetChild(0).GetComponent<Image>().color = Color.white;
    }





}
