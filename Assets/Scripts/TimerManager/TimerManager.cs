using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Slider Timer;

    public Image fillImage;

    private Time MaxTime;
    private float CurrentTime;
    public float totalTime = 180f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = totalTime;

        Timer.maxValue = totalTime;
        Timer.value = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            Timer.value = CurrentTime;
        }
    }

    public void DecreaseTime(float bar)     //bar = Ã¼·Â¹Ù
    {
        CurrentTime -= bar;
        CurrentTime = Mathf.Clamp(CurrentTime, 0f, totalTime);
        
        if (CurrentTime <= 0f)
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
}
