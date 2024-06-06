using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted = false;
    private GameTimer gameTimer;
    public GameObject mainMenu;  // Reference to the MainMenu panel
    public GameObject gameplayUI;  // Reference to the GameplayUI

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        gameplayUI.SetActive(false);  // Hide Gameplay UI at the start
        gameTimer.enabled = false;  // Disable the timer at the start
    }

    public void StartGame()
    {
        gameStarted = true;
        gameTimer.enabled = true;  // Enable the timer
        gameTimer.StartTimer();  // Start the timer
        mainMenu.SetActive(false);  // Deactivate the MainMenu panel
        gameplayUI.SetActive(true);  // Show Gameplay UI
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



