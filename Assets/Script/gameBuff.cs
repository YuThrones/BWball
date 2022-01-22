using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using gameEnum;

namespace gameBuff
{

    public class Buff
    {
        public bool isDestroy = false;
        public virtual void Start(GameObject gameObject)
        {

        }
        public virtual void Update(GameObject gameObject)
        {

        }

        public virtual void FixedUpdate(GameObject gameObject)
        {

        }

        public virtual void End(GameObject gameObject)
        {

        }

    }

    public class SlowCameraBuffEffect: Buff
    {
        public float slowRate;
        public float slowTime;
        public float duration;
        public float recoverTime;
        private float timeCount = 0;
        public float curRate = 1;

        public SlowCameraBuffEffect(float slowRate, float slowTime, float duration, float recoverTime)
        {
            this.slowRate =  slowRate;
            this.slowTime = slowTime;
            this.duration = duration;
            this.recoverTime = recoverTime;
        }

        override public void Update(GameObject gameObject)
        {
            timeCount += Time.deltaTime;
            if (timeCount < slowTime)
            {
                curRate = 1 - timeCount / slowTime * slowRate;
            }
            else if (timeCount < slowTime + duration)
            {
                curRate = 1 - slowRate;
            }
            else if (timeCount < slowTime + duration + recoverTime)
            {
                curRate = 1 - (slowTime + duration + recoverTime - timeCount) / recoverTime * slowRate;
            }
            else
            {
                Debug.Log("¼õËÙ½áÊø");
                isDestroy = true;
            }
        }
    }

    public class BallColorBuffEffect: Buff
    {
        public GameColor changeColor;
        public float duration;
        private float timeCount = 0;

        public BallColorBuffEffect(GameColor changeColor, float duration)
        {
            this.changeColor = changeColor;
            this.duration = duration;
        }

        override public void Update(GameObject gameObject)
        {
            timeCount += Time.deltaTime;
        }

        override public void FixedUpdate(GameObject gameObject)
        {
            if (timeCount > duration)
            {
                End(gameObject);
            }
        }

        override public void Start(GameObject gameObject)
        {
            gameObject.GetComponent<controll>().ChangeColor(changeColor);
        }

        override public void End(GameObject gameObject)
        {
            isDestroy = true;
            gameObject.GetComponent<controll>().RecoverColor();
        }
    }
}
