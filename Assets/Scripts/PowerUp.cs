using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class PowerUp : MonoBehaviour
{
    private string power;
    private string item;

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI itemText;
    

    // Reference to the health controller
    public HealthController healthController;

    private void Start()
    {
        // Initialize the HealthController component
        healthController = GetComponent<HealthController>();

        // Check if the HealthController component is attached
        if (healthController == null)
        {
            Debug.LogError("HealthController reference is not set!");
        }

        power = "None"; // Initial power setting
        SetPowerText(); // Update power display
        item = "None";  // Initial item setting
        SetItemText();  // Update item display
    }

    void OnTriggerEnter(Collider other)
    {
        // Collect power-ups and items, and deactivate them
        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
            power = other.gameObject.name;
            SetPowerText();
        }

        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            item = other.gameObject.name;
            SetItemText();
        }

        // Take damage if collides with a hurtful object
        if (other.gameObject.CompareTag("hurt"))
        {
            healthController.TakeDamage(10.0f); // Specify damage amount
        }
    }
    // Update the power text UI

    void SetPowerText()
    {
        powerText.text = "Power: " + power;

    }

    // Update the item text UI
    void SetItemText()
    {
        itemText.text = "Item: " + item;
    }
}
