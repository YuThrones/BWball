using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
    public float speed;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

        //¼ì²âÇòÊÇ·ñÔÚÆÁÄ»ÄÚ
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in balls)
        {
            Vector3 pos = camera.WorldToViewportPoint(ball.transform.position);
            if (pos.y < 0 || pos.y > 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControll>().GameOver();
            }
        }
    }

    void FixedUpdate()
    {
    }
}
