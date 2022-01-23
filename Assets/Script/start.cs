using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using GlobalData;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject replayGroup;
    public GameObject timeText;
    public Button btn1;
    public Button btn2;
    void Start()
    {
		btn1.onClick.AddListener (OnClick);
		btn2.onClick.AddListener (OnClick);
        if (GDATA.lastTime < 0)
        {
            replayGroup.SetActive(false);
        }
        else
        {
            replayGroup.SetActive(true);
            TMP_Text txt = timeText.GetComponent<TMP_Text>();
            txt.text = GetTime(GDATA.lastTime);
        }
    }

    string GetTime(float time)
    {
        float h = Mathf.FloorToInt(time / 3600);
        float m = Mathf.FloorToInt(time / 60 - h * 60);
        float s = Mathf.FloorToInt(time - m * 60 - h * 3600);
        return h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("OnClick");
        SceneManager.LoadScene("GameScene");
    }
}
