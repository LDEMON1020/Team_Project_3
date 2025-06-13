using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevHelpScene : MonoBehaviour
{
    public string PrevScene;

    public void PreviousScene()
    {
        SceneManager.LoadScene(PrevScene);
    }
}
