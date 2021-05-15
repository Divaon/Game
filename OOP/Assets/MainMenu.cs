using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool click = false;

    public void Pause(bool pause)
    {
        if(click==false)
        {
            click = true;
            Time.timeScale = 0;
        }
        else if (click == true)
        {
            click = false;
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
