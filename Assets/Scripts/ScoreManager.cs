using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreboardPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI topScoresText; // New TextMeshPro component for displaying top scores
    private GameTimer gameTimer;

    private List<float> topScores = new List<float>();

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        scoreboardPanel.SetActive(false); // Hide the scoreboard at the start
        LoadScores(); // Load scores when the game starts
    }

    public void ShowScoreboard()
    {
        float finalTime = gameTimer.GetCurrentTime();
        AddScore(finalTime);
        string minutes = ((int)finalTime / 60).ToString();
        string seconds = (finalTime % 60).ToString("f2");
        scoreText.text = "Your Time: " + minutes + ":" + seconds;
        DisplayTopScores();
        scoreboardPanel.SetActive(true); // Show the scoreboard
        gameTimer.StopTimer();
        SaveScores(); // Save scores when the game ends
    }

    private void AddScore(float score)
    {
        topScores.Add(score);
        topScores = topScores.OrderBy(t => t).Take(5).ToList(); // Keep only the top 5 scores
    }

    private void DisplayTopScores()
    {
        topScoresText.text = "Top Scores:\n";
        foreach (float score in topScores)
        {
            string minutes = ((int)score / 60).ToString();
            string seconds = (score % 60).ToString("f2");
            topScoresText.text += minutes + ":" + seconds + "\n";
        }
    }

    private void SaveScores()
    {
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetFloat("TopScore" + i, topScores[i]);
        }
        PlayerPrefs.SetInt("TopScoreCount", topScores.Count);
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        topScores.Clear();
        int count = PlayerPrefs.GetInt("TopScoreCount", 0);
        for (int i = 0; i < count; i++)
        {
            topScores.Add(PlayerPrefs.GetFloat("TopScore" + i, 0));
        }
    }
}


