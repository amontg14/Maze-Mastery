using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuOBJ;
    public bool isPlaying; 

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

  

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)

        MainMenuOBJ.SetActive(false);

    }


    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenuOBJ.SetActive(true);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}