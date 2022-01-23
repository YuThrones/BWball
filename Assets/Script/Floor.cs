using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameEnum;

public class Floor : MonoBehaviour
{
    public GameColor color;
    public float delayTime;
    bool delayDestroying;
    double delayTimeCount;
    
    // Start is called before the first frame update
    void Start()
    {
        delayDestroying = false;
        delayTimeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    public void DestroyAfterDelay()
    {
        if (delayDestroying)
        {
            return;
        }
        delayDestroying = true;
        Invoke("DestroyFloor", delayTime);
    }

    void CheckDelayDestroy()
    {
        if (delayTimeCount >= delayTime)
        {
            Destroy(gameObject);
        }
    }

    void DestroyFloor()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
