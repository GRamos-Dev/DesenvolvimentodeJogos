using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealt : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Barradevida healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.ColocarvidaMaxima(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.AlterarVida(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Carrega o menu principal quando o jogador morre
        SceneManager.LoadScene("MainMenu");
        
        // Reseta o score quando o jogador morre
        ScoreManager.instance?.ResetScore();
    }
}