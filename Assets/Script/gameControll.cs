using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void GameOver()
    {
        Debug.Log("”Œœ∑Ω· ¯");
        SceneManager.LoadScene("MainScene");
    }
}
