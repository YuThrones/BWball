using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameEnum;

public class controll : MonoBehaviour
{

    public int jumpForce;
    public int speed;
    private bool isJump;
    //public int color;
    public GameColor color;
    // public Transform transform;
    // Start is called before the first frame update
    Rigidbody2D rigitbody;
    void Start()
    {
        rigitbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int input = GetControllDir();

        if (IsPress(input, InputControll.Left) && IsPress(input, InputControll.Right)) {
            //都按着维持原来速度
        }
        else if (IsPress(input, InputControll.Left)) {
            rigitbody.velocity = new Vector2(-speed, rigitbody.velocity.y);
        }
        else if (IsPress(input, InputControll.Right)) {
            rigitbody.velocity = new Vector2(speed, rigitbody.velocity.y);
        }
        else
        {
            rigitbody.velocity = new Vector2(0, rigitbody.velocity.y);
        }

        //检测是否碰到地面
        
        if (!isJump && IsPress(input, InputControll.Up)) {
            //rigitbody.AddForce(Vector2.up * jumpForce);
            rigitbody.velocity = new Vector2(rigitbody.velocity.x, jumpForce);
            isJump = true;
        }

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

    }

    bool IsPress(int input, InputControll controll)
    {
        return (input & (int)controll) > 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        //if (hit.collider != null && rigitbody.velocity.y < 0.0001)
        //{
        //    Debug.Log("取消跳跃限制");
        //    isJump = false;
        //}

        if (collision.gameObject.tag == "Floor")
        {
            if (collision.gameObject.transform.position.y < gameObject.transform.position.y && rigitbody.velocity.y < 0.01)
            {
                //Debug.Log("取消跳跃限制");
                isJump = false;


                if (collision.gameObject.GetComponent<Floor>().color == GameColor.None)
                {
                    //Debug.Log("没有颜色的瓷砖");
                }
                else if (collision.gameObject.GetComponent<Floor>().color == GameColor.Gray)
                {
                    //Debug.Log("灰色瓷砖");
                    collision.gameObject.GetComponent<Floor>().DestroyAfterDelay();
                }
                else if (collision.gameObject.GetComponent<Floor>().color != this.color)
                {
                    //Debug.Log("不同颜色瓷砖");
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControll>().GameOver();
                }
                else
                {
                    //Debug.Log("同色瓷砖");
                }
            }
        }

            
    }

    int GetControllDir()
    {
        int input = 0;
        //if (color == (int)GameColor.Black)
        if (color == GameColor.Black)
        {
            if (Input.GetKey(KeyCode.A))
            {
                input |= (int)InputControll.Left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                input |= (int)InputControll.Right;
            }

            if (Input.GetKey(KeyCode.W))
            {
                input |= (int)InputControll.Up;
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                input |= (int)InputControll.Left;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                input |= (int)InputControll.Right;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                input |= (int)InputControll.Up;
            }
        }
        return input;
    }

    void FixedUpdate() {
    }
}
