using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Agora usando TMP
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FindScoreText();
        UpdateScoreUI();
    }

    void FindScoreText()
    {
        // Se não foi atribuído no Inspector, tenta encontrar
        if (scoreText == null)
        {
            scoreText = GameObject.Find("TMPScoreText")?.GetComponent<TextMeshProUGUI>();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText == null) FindScoreText();
        if (scoreText != null) scoreText.text = $"Score: {score}";
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Chamado quando uma nova cena é carregada
    public void OnSceneLoaded()
    {
        FindScoreText();
        UpdateScoreUI();
    }
}