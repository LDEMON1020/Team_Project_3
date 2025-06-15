using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshProUGUI GameOverText;


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
        else if (CurrentTime <= 0 && !snackGame.isGameOver)
        {
            snackGame.isGameOver = true;
            GameOverText.text = "타이머의 시간이 다 지났습니다.";
        }
       
    }

    public void DecreaseHP(float bar)     //bar = 체력바
    {
        currentHP -= bar;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
        UpdateHPUI();

        if (currentHP == 0 && !snackGame.isGameOver)
        {
            snackGame.isGameOver = true;
            GameOverText.text = "HP가 0이 되었습니다.";
        }
    }

    public void DecreaseTime(float bar)     //bar = 체력바
    {
        CurrentTime -= bar;
        CurrentTime = Mathf.Clamp(CurrentTime, 0f, totalTime);
    }

    void UpdateHPUI()
    {
        if (Hp != null)
            Hp.value = currentHP;
    }

 
}
