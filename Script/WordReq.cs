using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordReq : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isBoss = false;

    public GameObject[] wordsneeded;
    public GameObject[] wordsactive;
    public int currentword = 0;

    [SerializeField, Header("Word Spawn")]
    public GameObject[] WordToSpawn;
    public GameObject[] WordSpawned;

    GameObject wordparent;
    public GameObject Canvas;
    public GameObject group;

    public GameObject wood;
    private InventoryManager inventoryManager;
    public void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();

        SpawnWord();
        SetSiblingIndex();
        wordsactive = new GameObject[wordsneeded.Length];
        for (int i = 0; i < wordsneeded.Length; i++)
        {

            wordsactive[i] = Instantiate(wordsneeded[i], new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Req").transform);
            wordsactive[i].transform.localPosition = new Vector3(0, 0, 0);
            wordsactive[i].GetComponent<Button>().interactable = false;
            // wordsactive[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;

        }



    }

    // Update is called once per frame
    void Update()
    {
        if (currentword == wordsneeded.Length)
        {
            if(isBoss){
                BossAttack();
                Canvas.SetActive(false);
            }
            
            Debug.Log("You Win");
            group.SetActive(true);
            inventoryManager.WoodCompleted();
            wood.SetActive(true);
            Destroy(Canvas);
        }

    }

    public void SpawnWord()
    {
        int wordmustspawn = wordsneeded.Length;
        WordSpawned = new GameObject[10];

        for (int i = 0; i < wordmustspawn; i++)
        {
            WordSpawned[i] = Instantiate(wordsneeded[i], new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Word Container").transform);
            WordSpawned[i].transform.localPosition = new Vector3(0, 0, 0);
        }

        for (int i = 0; i < 10 - wordmustspawn; i++)
        {
            int rand = Random.Range(0, WordToSpawn.Length);
            // Spawn Word Needed
            WordSpawned[i] = Instantiate(WordToSpawn[rand], new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Word Container").transform);
            WordSpawned[i].transform.localPosition = new Vector3(0, 0, 0);

            // Shuffle

        }
    }

    public void DestroyWord()
    {
        wordparent = GameObject.FindGameObjectWithTag("Word Container");
        while (wordparent.transform.childCount > 0)
        {
            DestroyImmediate(wordparent.transform.GetChild(0).gameObject);
        }

    }

    public void SetSiblingIndex()
    {
        for (int i = 0; i < wordsneeded.Length; i++)
        {
            int rand = Random.Range(0, wordsneeded.Length);
            WordSpawned[i].transform.SetSiblingIndex(rand);
        }
    }

    public void BossAttack()
    {  
        GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().EnemyTurn();
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Villian>().TakeDamage(10);
    }

    public void Reset(){
        currentword = 0;
    }

}
