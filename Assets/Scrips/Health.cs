using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public int scoreValue = 10; // Pontos que o jogador ganha ao matar este inimigo

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Inimigo tomou dano! Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Inimigo morreu!");
        // Notifica o ScoreManager para adicionar pontos
        ScoreManager.instance?.AddScore(scoreValue);
        Destroy(gameObject);
    }
}