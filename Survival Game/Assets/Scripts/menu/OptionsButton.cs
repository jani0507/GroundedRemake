using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
   

     public GameObject mainMenu;
     public GameObject optionsMenu;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }


    }

    public void Quit()
    {
        Application.Quit();
    }
}
