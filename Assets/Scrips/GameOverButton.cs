using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        // Destroi todos os objetos persistentes primeiro
        DestroyPersistentObjects();
        
        // Garante que o tempo volte ao normal
        Time.timeScale = 1f;
        
        // Carrega o menu principal
        SceneManager.LoadScene("MainMenu");
    }

    void DestroyPersistentObjects()
    {
        // Destroi o GameManager se existir
        if (GameManager.instance != null)
        {
            Destroy(GameManager.instance.gameObject);
            GameManager.instance = null;
        }
        
        // Destroi o ScoreManager se existir
        if (ScoreManager.instance != null)
        {
            Destroy(ScoreManager.instance.gameObject);
            ScoreManager.instance = null;
        }
    }
}