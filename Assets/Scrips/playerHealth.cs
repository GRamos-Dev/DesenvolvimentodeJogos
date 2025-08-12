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
    // 1. Reset time scale
    Time.timeScale = 1f;
    
    // 2. Destroi todos os objetos persistentes
    foreach (var obj in FindObjectsOfType<GameObject>())
    {
        if (obj.scene.buildIndex == -1) // Objetos DontDestroyOnLoad
        {
            Destroy(obj);
        }
    }
    
    // 3. Carrega o menu
    SceneManager.LoadScene("MainMenu");
    }
}