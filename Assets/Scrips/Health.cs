using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public int scoreValue = 10;

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
        ScoreManager.instance?.AddScore(scoreValue);

        // Aqui avisa o EnemySpawner que esse inimigo morreu
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.OnEnemyKilled();
        }

        Destroy(gameObject);
    }
}
