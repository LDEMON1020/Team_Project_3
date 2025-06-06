using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTimeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ModChoice(TimeAttack_Mod)");
    }
}
