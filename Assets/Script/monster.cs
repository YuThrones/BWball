using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameEnum;

public class monster : MonoBehaviour
{

    public int speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Vector3 pos = camera.WorldToViewportPoint(gameObject.transform.position);
        if (pos.y < 0 || pos.x < 0 || pos.x > 1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                if (rb.velocity.x == 0)
                {
                    if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
                    {
                        //地板偏左往左滚
                        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(1 * speed, rb.velocity.y);
                    }
                }
            }
        }
        else if (collision.gameObject.tag == "Ball")
        {
            //怪物撞到人，直接杀死
            Debug.Log("怪物撞到人，直接杀死"+ this + collision.gameObject + gameObject.transform.position);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControll>().GameOver();
        }

    }

    void FixedUpdate()
    {
    }
}
