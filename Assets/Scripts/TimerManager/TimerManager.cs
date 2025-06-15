using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Slider Timer;

    public Image fillImage;

    private float CurrentTime;
    public float totalTime = 180;

    private SnackGame snackGame;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = totalTime;

        Timer.maxValue = totalTime;
        Timer.value = totalTime;

        snackGame = FindObjectOfType<SnackGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            Timer.value = CurrentTime;
        }

        if (CurrentTime <= 0 && !snackGame.isGameOver)
        {
            snackGame.isGameOver = true;
        }
    }

    public void DecreaseTime(float bar)     //bar = Ã¼·Â¹Ù
    {
        CurrentTime -= bar;
        CurrentTime = Mathf.Clamp(CurrentTime, 0f, totalTime);
    }
}
