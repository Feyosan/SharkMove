using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100; // The starting health of the player
    public int currentHealth; // The current health of the player
    public TextMeshProUGUI healthText; // TextMesh
    //public GameObject gameOverScreen; // Game Over screen object

    void Awake()
    {
        currentHealth = startingHealth;
        // Assign the health text
        healthText.text = startingHealth.ToString();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthText.text = "0";
            Time.timeScale = 0f;
            GameOverManager.gameOverManager.CallGameOver();
        }
        else
        {
            AudioSource explosion = GetComponent<AudioSource>();
            healthText.text = currentHealth.ToString();
            explosion.Play();
        }
    }

    
}
