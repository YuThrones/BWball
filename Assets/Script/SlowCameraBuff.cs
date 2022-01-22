using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameBuff;

public class SlowCameraBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowRate;
    public float slowTime;
    public float duration;
    public float recoverTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("¼õ»ºÏà»ú");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<buffContainer>().AddBuff(new SlowCameraBuffEffect( slowRate, slowTime, duration, recoverTime) );
            Destroy(gameObject);
        }
    }
}
