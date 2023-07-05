using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private Animator anim;
    public GameObject sfxClick;
    //private Music music;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Invoke("anu", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(Transition(scene));
    }

    void anu()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Transition(string scene)
    {
        //Instantiate(sfxClick, transform.position, transform.rotation);
        //gameObject.SetActive(true);
        anim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

    
}
