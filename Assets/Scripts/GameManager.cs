using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted = false;
    private GameTimer gameTimer;
    private RotateCamera rotateCamera;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        rotateCamera = FindObjectOfType<RotateCamera>(); // Find the RotateCamera script
        gameTimer.enabled = false; // Disable the timer at the start
    }

    public void StartGame()
    {
        gameStarted = true;
        gameTimer.enabled = true; // Enable the timer
        gameTimer.StartTimer(); // Start the timer
        GameObject.Find("MainMenu").SetActive(false);
        rotateCamera.enabled = false; // Disable the RotateCamera script
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



