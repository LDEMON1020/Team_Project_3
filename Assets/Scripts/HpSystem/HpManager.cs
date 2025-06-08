using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{

    public Slider Hp;

    private float maxHP = 1.0f;
    private float currentHP;
    private SnackGame snackGame;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();

        snackGame = FindObjectOfType<SnackGame>();
    }

    public void DecreaseHP(float bar)     //bar = Ã¼·Â¹Ù
    {
        currentHP -= bar;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
        UpdateHPUI();

        if (currentHP <= 0f)
        {
            snackGame.isGameOver = true;
        }
    }

    void UpdateHPUI()
    {
        if (Hp != null)
            Hp.value = currentHP;
    }

  

    // Update is called once per frame
    void Update()
    {

    }
}
