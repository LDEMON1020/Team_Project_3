using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAllIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoAllIn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlayScene(All_In_Mod)");
    }
}
