using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameBuff;
using gameEnum;

public class ChangeBallBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameColor changeColor;
    public float duration;
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
            other.gameObject.GetComponent<buffContainer>().AddBuff(new BallColorBuffEffect(changeColor, duration));
            Destroy(gameObject);
        }
    }
}
