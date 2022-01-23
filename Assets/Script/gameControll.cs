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
        Debug.Log("”Œœ∑Ω· ¯");
        GDATA.lastTime = aliveTime;
        SceneManager.LoadScene("MainScene");
    }
}
