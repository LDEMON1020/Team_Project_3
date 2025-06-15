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
        NormalMod.text = "Normal Mod : " + HighScore.Load(6).ToString();
        ShakingMod.text = "Shaking Mod : " + HighScore.Load(7).ToString();
        HPMod.text = "HP Mod : " + HighScore.Load(8).ToString();
        TimeAttackMod.text = "TimeAttack Mod : " + HighScore.Load(9).ToString();
        All_InMod.text = "All In Mod : " + HighScore.Load(10).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
