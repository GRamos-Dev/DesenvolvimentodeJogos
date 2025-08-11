using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameOverButton : MonoBehaviour
{
    // A cena de Game Over não precisa mais ser serializada publicamente
    // Já que o GameManager vai lidar com a transição.

    private void Start()
    {
        // Garante que o Game Manager existe antes de adicionar o listener
        if (GameManager.instance != null)
        {
            // Adiciona o listener para chamar o método LoadMainMenu do GameManager
            GetComponent<Button>().onClick.AddListener(GameManager.instance.LoadMainMenu);
        }
        else
        {
            Debug.LogError("GameManager não encontrado. O botão não vai funcionar.");
            // Fallback para carregar a cena diretamente se o GameManager não estiver presente
            GetComponent<Button>().onClick.AddListener(LoadMainMenuDirectly);
        }
    }

    // Este método é um fallback, caso o GameManager não seja encontrado
    private void LoadMainMenuDirectly()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}