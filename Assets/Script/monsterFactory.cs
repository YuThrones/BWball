using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameEnum;

public class monsterFactory : MonoBehaviour
{

    public float yOffset;
    public GameObject[] monsterList;

    private bool isCreate;
    void Start()
    {
        isCreate = false;
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCreate)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Vector3 monsterPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yOffset, gameObject.transform.position.z);
                GameObject monsterPrefab = monsterList[Random.Range(0, monsterList.Length - 1)];
                GameObject.Instantiate(monsterPrefab, monsterPos, Quaternion.identity);
                isCreate = true;
            }
        }
        
    }

    void FixedUpdate()
    {
    }
}
