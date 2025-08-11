using UnityEngine;

public class playerHealt : MonoBehaviour
{
    //vida do personagem 
    public float maxHealth = 100f;
    public float currentHealth;
    public Barradevida healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.ColocarvidaMaxima(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

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
        // Implemente aqui o que acontece quando o jogador morre
        Debug.Log("Player died!");
        // Exemplo: Recarregar a cena, mostrar tela de game over, etc.
    }
}
