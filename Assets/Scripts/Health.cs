using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (CompareTag("Player"))
        {
            // Si le joueur meurt → restart
            Invoke("RestartScene", 1f);
            return;
        }
        // Si c'est un ennemi, on regarde s'il en reste
        if (CompareTag("Ennemis"))
        {
            if (GameObject.FindObjectsByType<EnnemiShooter>(FindObjectsSortMode.None).Length == 1)
            {
                // C'était le dernier → restart
                Invoke("RestartScene", 1f);
                return;
            }
        }
        Destroy(gameObject);
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
