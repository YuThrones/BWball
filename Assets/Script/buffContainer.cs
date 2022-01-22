using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameBuff;

public class buffContainer : MonoBehaviour
{
    private List<Buff> buffs;
    void Start()
    {
        buffs = new List<Buff>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Buff buff in buffs)
        {
            buff.Update(gameObject);
        }
    }

    void FixedUpdate() {
        List<Buff> destroyList = new List<Buff>();
        foreach (Buff buff in buffs)
        {
            buff.FixedUpdate(gameObject);
            if (buff.isDestroy)
            {
                destroyList.Add(buff);
            }
        }

        foreach (Buff buff in destroyList)
        {
            buffs.Remove(buff);
        }
    }

    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        buff.Start(gameObject);
    }

    public float GetSpeedRate()
    {
        
        float speedRate = 1;
        foreach (Buff buff in buffs)
        {
            if (buff is SlowCameraBuffEffect)
            {
                SlowCameraBuffEffect slowBuff = (SlowCameraBuffEffect)buff;
                speedRate *= slowBuff.curRate;
            }
        }
        return speedRate;
    }
}
