using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    public Text healthText;
    public float Health;
    public float startingHealth = 100;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.

    void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        
        Health = currentHealth;
        healthText.text = "Health:" + Health.ToString();
    }
}
