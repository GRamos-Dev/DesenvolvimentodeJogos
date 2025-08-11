using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Garante que o ScoreManager seja atualizado quando uma nova cena é carregada
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.OnSceneLoaded();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
            // Reseta o score quando uma nova partida começa
            ScoreManager.instance?.ResetScore();
        }
    }

    public void IniciaJogo()
    {
        SceneManager.LoadScene("SampleScene");
        // Reseta o score quando uma nova partida começa
        ScoreManager.instance?.ResetScore();
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}