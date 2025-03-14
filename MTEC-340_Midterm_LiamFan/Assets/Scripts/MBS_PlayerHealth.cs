using UnityEngine;
using TMPro; // For UI updates
using UnityEngine.SceneManagement; // For scene management
using System.Collections; // Required for IEnumerator and coroutines

public class MBS_PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] public TextMeshProUGUI healthText; // Reference to UI text

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
        MBS_GameBehaviour.Instance.State = MBS_GameBehaviour.Utilities.GameplayState.Lose; // Switch to "Lose" state

        // Load the Home scene after a delay
        StartCoroutine(LoadHomeSceneAfterDelay());
    }

    private IEnumerator LoadHomeSceneAfterDelay()
    {
        // Wait for a few seconds before switching scenes
        yield return new WaitForSeconds(2); // Adjust the delay time as needed

        // Switch to the Home scene
        SceneManager.LoadScene("Home");
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth;
        }
    }
}

