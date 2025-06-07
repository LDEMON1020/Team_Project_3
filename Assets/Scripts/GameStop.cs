using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStop : MonoBehaviour
{

    private bool isPaused = false;

    public void Open()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Close()
    {
        Time.timeScale = 1f;
    }

}
