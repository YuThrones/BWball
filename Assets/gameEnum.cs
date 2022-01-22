using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace gameEnum
{

    public enum GameColor
    {
        None = 0,
        Black = 1,
        White = 2,
        Gray = 3,
    }

    public enum InputControll
    {
        Up = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
    }
}
