using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettingsBtn : MonoBehaviour
{
    public GameObject startGame;
    public GameObject backMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backMenu.SetActive(true);
            SceneManager.LoadScene("MainMenu");

        }
            if (Input.GetKeyDown(KeyCode.G))
        {
            startGame.SetActive(true);
            SceneManager.LoadScene("Game");
        }
    }
}
