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
        if (CurrentTime <= 0 && !snackGame.isGameOver)
        {
            snackGame.isGameOver = true;
        }
    }

    public void DecreaseHP(float bar)     //bar = ü�¹�
    {
        currentHP -= bar;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
        UpdateHPUI();
    }

    public void DecreaseTime(float bar)     //bar = ü�¹�
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
