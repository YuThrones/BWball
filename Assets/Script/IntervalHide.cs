using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalHide : MonoBehaviour
{
    public float hideInterval;
    public float hideTime;
    float timeCount;
    int state;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
    }

    void FixedUpdate()
    {
        CheckChangeState();
    }

    void CheckChangeState()
    {
        if (state == 1)
        {
            //ÊµÌå×´Ì¬
            if (timeCount > hideInterval)
            {
                Debug.Log("Òþ²Ø");
                state = 0;
                timeCount = 0;
                //gameObject.SetActive(false);
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
        else
        {
            //Òþ²Ø×´Ì¬
            if (timeCount > hideInterval)
            {
                Debug.Log("ÏÔÊ¾");
                state = 1;
                timeCount = 0;
                //gameObject.SetActive(true);
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
