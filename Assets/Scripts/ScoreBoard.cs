using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI NormalMod;
    public TextMeshProUGUI ShakingMod;
    public TextMeshProUGUI HPMod;
    public TextMeshProUGUI TimeAttackMod;
    public TextMeshProUGUI All_InMod;
    // Start is called before the first frame update
    void Start()
    {
        NormalMod.text = "Normal Mod : " + HighScore.Load(2).ToString();
        ShakingMod.text = "Shaking Mod : " + HighScore.Load(3).ToString();
        HPMod.text = "HP Mod : " + HighScore.Load(4).ToString();
        TimeAttackMod.text = "TimeAttack Mod : " + HighScore.Load(5).ToString();
        All_InMod.text = "All In Mod : " + HighScore.Load(6).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
