using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGoundControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, cameraPos.y, gameObject.transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, cameraPos.y, gameObject.transform.position.z);
    }
}
