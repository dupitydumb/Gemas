using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandLight : MonoBehaviour
{
    public GameObject wandholder;
    public bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wandholder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!used)
        {
            transform.position = wandholder.transform.position;
        }
    }
}
