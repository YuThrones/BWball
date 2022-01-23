using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GlobalData;
public class gameControll : MonoBehaviour
{
    // Start is called before the first frame update
    private float aliveTime;
    private bool isEnd = false;
    void Start()
    {
        aliveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;
        GameObject.FindGameObjectWithTag("TimeText").GetComponent<TMP_Text>().text = "Time:" + (int)aliveTime;
    }

    public void GameOver()
    {
        if (isEnd)
        {
            return;
        }
        isEnd = true;
        Debug.Log("游戏结束");
        GDATA.lastTime = aliveTime;
        gameObject.GetComponent<AudioSource>().Play();

        //播所有球的死亡动画
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            ball.GetComponent<controll>().OnDie();
        }

        Invoke("DelayEnd", 1);
    }

    void DelayEnd()
    {
        SceneManager.LoadScene("MainScene");
    }
}
