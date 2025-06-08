using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private const string KEY = "HighScore";

    public static int Load(int Mod)
    {
        return PlayerPrefs.GetInt(KEY + "_" + Mod, 0);
    }

    public static void Tryset(int Mod, int newScore)
    {
        if (newScore <= Load(Mod))
            return;

        PlayerPrefs.SetInt(KEY + "_" + Mod, newScore);
        PlayerPrefs.Save();
    }
}
