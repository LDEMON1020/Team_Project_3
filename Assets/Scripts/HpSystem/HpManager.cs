using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{

    public Slider Hp;

    private float maxHP = 1.0f;
    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();

    }

    public void DecreaseHP(float bar)     //bar = 체력바
    {
        currentHP -= bar;
        currentHP = Mathf.Clamp(currentHP, 0f, maxHP);
        UpdateHPUI();

        if (currentHP < 0f)
        {
            GameOver();
        }
    }

    void UpdateHPUI()
    {
        if (Hp != null)
            Hp.value = currentHP;
    }

    void GameOver()
    {
        //게임오버 판넬 띄우기 이동 ( 아직 구현 X )
    }

    // Update is called once per frame
    void Update()
    {

    }
}
