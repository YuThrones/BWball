using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float addSpeed;
    public Camera selfCemera;
    //public float speedRate;
    // Start is called before the first frame update
    void Start()
    {
        //speedRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        //检测球是否在屏幕内
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in balls)
        {
            Vector3 pos = selfCemera.WorldToViewportPoint(ball.transform.position);
            if (pos.y < -0.1 || pos.y > 1 || pos.x < -0.1 || pos.x > 1.1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControll>().GameOver();
            }
        }
    }

    void FixedUpdate()
    {
        //速度会每秒增加
        if (speed < maxSpeed)
        {
            speed += addSpeed * Time.fixedDeltaTime;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + GetSpeed() * Time.fixedDeltaTime, transform.position.z);
    }

    private float GetSpeed()
    {
        if (gameObject.GetComponent<buffContainer>())
        {
            return speed * gameObject.GetComponent<buffContainer>().GetSpeedRate();
        }
        return speed;
    }
}
