using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public GameObject scoreboardPanel; // Reference to the UI panel for the scoreboard
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI for TextMeshPro components
    private GameTimer gameTimer;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        scoreboardPanel.SetActive(false); // Hide the scoreboard at the start
    }

    public void ShowScoreboard()
    {
        float finalTime = gameTimer.GetCurrentTime();
        string minutes = ((int)finalTime / 60).ToString();
        string seconds = (finalTime % 60).ToString("f2");
        scoreText.text = "Your Time: " + minutes + ":" + seconds;
        scoreboardPanel.SetActive(true); // Show the scoreboard
        gameTimer.StopTimer();
    }
}


