using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameEnum;

public class ChangeFloorBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public float effectRadius;
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
            GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
            foreach(GameObject floor in floors)
            {
                if (Vector2.Distance(gameObject.transform.position, floor.transform.position) < effectRadius)
                {
                    floor.GetComponent<Floor>().color = GameColor.None;
                    Sprite sp = floor.GetComponent<SpriteRenderer>().sprite;
                }
            }
            Destroy(gameObject);
        }
    }
}
