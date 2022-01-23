using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private GameObject[,] bgs;
    public Camera mainCamera;
    public Vector2 bgSize;
    public Vector3 originPos;

    void Start()
    {
        Debug.Log("³ß´ç" + prefab.GetComponent<SpriteRenderer>().size);
        bgSize = prefab.GetComponent<SpriteRenderer>().size;
        originPos = prefab.transform.position;
        bgs = new GameObject[3, 2];
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                GameObject temp = GameObject.Instantiate(prefab);
                temp.transform.SetParent(prefab.transform.parent);
                temp.transform.position = new Vector3(originPos.x + j * bgSize[0], originPos.y + i * bgSize[1], 0);
                bgs[i, j] = temp;
            }
        }
        prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AutoChangePos();
    }

    void AutoChangePos()
    {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                if (mainCamera.WorldToViewportPoint(bgs[i, j].transform.position).y < -0.5 )
                {
                    bgs[i, j].transform.position = new Vector3(bgs[i, j].transform.position.x, bgs[i, j].transform.position.y + bgSize[1] * 3, bgs[i, j].transform.position.z);
                }
            }
        }
    }
}
