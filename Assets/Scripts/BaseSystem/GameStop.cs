using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour
{

    public void Open()
    {
        Time.timeScale = 0f;
    }

    public void Close()
    {
        Time.timeScale = 1f;
    }

}
