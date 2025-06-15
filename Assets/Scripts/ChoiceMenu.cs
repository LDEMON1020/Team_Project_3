using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceMenu : MonoBehaviour
{
    public string ChoiceScene;

    public void BacktoChoiceScene()
    {
        SceneManager.LoadScene(ChoiceScene);
    }
}
