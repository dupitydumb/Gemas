using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public int Timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
