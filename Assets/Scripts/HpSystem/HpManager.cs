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

    public void DecreaseHP(float bar)     //bar = ü�¹�
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
        //���ӿ��� �ǳ� ���� �̵� ( ���� ���� X )
    }

    // Update is called once per frame
    void Update()
    {

    }
}
