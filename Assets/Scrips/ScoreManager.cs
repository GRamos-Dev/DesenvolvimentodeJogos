using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
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

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Chamar quando uma nova cena é carregada para encontrar a nova UI de score
    public void OnSceneLoaded()
    {
        GameObject scoreTextObj = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreTextObj != null)
        {
            scoreText = scoreTextObj.GetComponent<Text>();
            UpdateScoreUI();
        }
    }
}