using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHealt : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Barradevida healthBar;
    public GameObject gameOverPanel; // Arraste o painel de Game Over aqui no Inspector

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.ColocarvidaMaxima(maxHealth);
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Garante que o painel está desativado no início
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        // Garante que a vida não fique abaixo de zero
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Atualiza a barra de vida
        if (healthBar != null)
        {
            healthBar.AlterarVida(currentHealth);
        }

        // Se a vida chegar a zero, o jogo acaba
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Exibir a tela de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Congelar o tempo do jogo
        Time.timeScale = 0f;

        // Opcional: desativar o jogador
        gameObject.SetActive(false);
    }

    // Método para voltar ao menu (será chamado pelo botão)
    public void ReturnToMenu()
    {
        // 1. Retorna o tempo ao normal
        Time.timeScale = 1f;

        // 2. Destrói os objetos persistentes que não queremos manter no menu
        if (ScoreManager.instance != null)
        {
            Destroy(ScoreManager.instance.gameObject);
        }
        if (GameManager.instance != null)
        {
            Destroy(GameManager.instance.gameObject);
        }

        // 3. Carrega o menu principal
        SceneManager.LoadScene("MainMenu");
    }
}