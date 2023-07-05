using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{

    Rigidbody2D rb;
    Slider slider;
    GameObject sliderObject;
    public GameObject DestroyVfx;
    CharMove player;

    public float time = 2f;

    private Transform light;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics2D.IgnoreCollision(GameObject.FindWithTag("Rock").GetComponent<Collider2D>(), GetComponent<Collider2D>(), );
        slider = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        sliderObject = transform.GetChild(0).gameObject;
        sliderObject.SetActive(false);
        light = GameObject.FindGameObjectWithTag("Light").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();

        // Get ScriptableObject
        var quest = player.questManager;
        // Debug.Log(quest.questManager[0].questName);
        if (quest.questManager[0].isComplete)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            time = 2f;
            slider.value = time;
            sliderObject.SetActive(false);
            var isused = GameObject.FindGameObjectWithTag("Light").GetComponent<WandLight>();
            isused.used = false;
        }


    }

    void OnMouseOver()
    {
        sliderObject.SetActive(true);
        Debug.Log("Mouse Enter");
        if (Input.GetMouseButton(0))
        {
            time -= Time.deltaTime;
            slider.value = time;
            time -= Time.deltaTime;
            var isused = GameObject.FindGameObjectWithTag("Light").GetComponent<WandLight>();
            isused.used = true;
            Vector3 target = transform.position;
            float t = time / 10.5f;
            t = t * t * (3f - 2f * t);
            light.position = Vector3.Slerp(light.position, target, t);
            if (time <= 0)
            {
                Destroy(gameObject);
                Instantiate(DestroyVfx, transform.position, Quaternion.identity);
                time = 2f;
                Debug.Log("Destroy");
                OnMouseExit();
            }
        }

    }

    private void OnMouseExit()
    {
        time = 2f;
        sliderObject.SetActive(false);
        var isused = GameObject.FindGameObjectWithTag("Light").GetComponent<WandLight>();
        isused.used = false;
    }

    // Move Light position to rock position slerp

    // Move Light position to rock position slerp



}
