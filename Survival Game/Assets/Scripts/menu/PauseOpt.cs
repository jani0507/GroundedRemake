using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOpt : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
       
        
       
    }
}
