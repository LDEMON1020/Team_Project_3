using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllInManager : MonoBehaviour
{
    public Slider Hp;
    public Slider Timer;

    private float maxHP = 1.0f;
    private float currentHP;

    private float CurrentTime;
    public float totalTime = 180f;

    private SnackGame snackGame;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();

        CurrentTime = totalTime;

        Timer.maxValue = totalTime;
        Timer.value = totalTime;

        snackGame = FindObjectOfType<SnackGame>();
    }

    void Update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            Timer.value = CurrentTime;
        }
    }

    public void DecreaseHP(float bar)     //bar = 체력바
    {
        currentHP -= bar;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
        UpdateHPUI();

        if (currentHP <= 0f)
        {
            snackGame.isGameOver = true;
        }
    }

    public void DecreaseTime(float bar)     //bar = 체력바
    {
        CurrentTime -= bar;
        CurrentTime = Mathf.Clamp(CurrentTime, 0f, totalTime);

        if (CurrentTime <= 0f)
        {
            snackGame.isGameOver = true;
        }
    }

    void UpdateHPUI()
    {
        if (Hp != null)
            Hp.value = currentHP;
    }

 
}
