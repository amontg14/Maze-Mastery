using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthController : MonoBehaviour
{
    public Image healthBarImage; // Assign this in the Inspector
    public float health = 100f; //starting health
    private float maxHealth = 100f; //max health
    public GameObject MainMenuOBJ; 

    // Call this method to reduce health
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Current Health: " + health);
        UpdateHealthBar();

        // Check if health is zero or less and reset game if true
        if (health <= 0)
        {
            ResetGame();
        }
    }

    // Updates the visual representation of the health bar
    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = health / maxHealth;
    }

    // Resets the game by reloading the current scene
    void ResetGame()
    {
        Debug.Log("Health is zero, resetting game.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        MainMenuOBJ.SetActive(true);
    }
}