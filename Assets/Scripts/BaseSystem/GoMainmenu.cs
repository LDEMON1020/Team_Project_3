using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMainmenu");
    }

}
