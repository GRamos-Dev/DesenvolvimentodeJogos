using UnityEngine;
using TMPro;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuração dos inimigos")]
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    [Header("Configuração das waves")]
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 3f;

    [Header("UI")]
    public TextMeshProUGUI waveText;       // Texto da wave
    public TextMeshProUGUI waveCompleteText; // Texto de "Wave Concluída"
    private CanvasGroup waveCanvasGroup;
    private CanvasGroup waveCompleteCanvasGroup;

    private int currentWave = 0;
    private int enemiesAlive = 0;

    void Start()
    {
        if (waveText != null)
        {
            waveCanvasGroup = waveText.GetComponent<CanvasGroup>();
            if (waveCanvasGroup == null)
                waveCanvasGroup = waveText.gameObject.AddComponent<CanvasGroup>();
            waveCanvasGroup.alpha = 0;
        }

        if (waveCompleteText != null)
        {
            waveCompleteCanvasGroup = waveCompleteText.GetComponent<CanvasGroup>();
            if (waveCompleteCanvasGroup == null)
                waveCompleteCanvasGroup = waveCompleteText.gameObject.AddComponent<CanvasGroup>();
            waveCompleteCanvasGroup.alpha = 0;
        }

        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        currentWave++;
        ShowWaveUI();

        yield return new WaitForSeconds(1f);

        enemiesAlive = enemiesPerWave;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

        enemiesPerWave += 10;
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            // Mostra "Wave Concluída" antes da próxima wave
            if (waveCompleteText != null)
                StartCoroutine(ShowWaveCompleteUI());

            StartCoroutine(StartNextWave());
        }
    }

    void ShowWaveUI()
    {
        if (waveText != null && waveCanvasGroup != null)
        {
            waveText.text = "Wave " + currentWave;
            StartCoroutine(FadeAndAnimateWaveText(waveText, waveCanvasGroup));
        }
    }

    IEnumerator ShowWaveCompleteUI()
    {
        waveCompleteText.text = "Wave Concluída!";
        yield return StartCoroutine(FadeAndAnimateWaveText(waveCompleteText, waveCompleteCanvasGroup));
    }

    IEnumerator FadeAndAnimateWaveText(TextMeshProUGUI textObj, CanvasGroup canvasGroup)
    {
        float fadeDuration = 1.5f;
        float displayTime = 3f;
        float moveDistance = 1f;

        Vector3 originalPos = textObj.rectTransform.localPosition;

        // Fade-in + subida temporária + zoom
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            canvasGroup.alpha = alpha;
            textObj.rectTransform.localPosition = originalPos + new Vector3(0, moveDistance * (t / fadeDuration), 0);
            textObj.rectTransform.localScale = Vector3.Lerp(Vector3.one * 0.8f, Vector3.one, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1;
        textObj.rectTransform.localPosition = originalPos + new Vector3(0, moveDistance, 0);
        textObj.rectTransform.localScale = Vector3.one;

        // Mantém visível
        yield return new WaitForSeconds(displayTime);

        // Fade-out + pequena subida extra temporária
        t = 0;
        Vector3 fadeOutStart = textObj.rectTransform.localPosition;
        Vector3 fadeOutEnd = fadeOutStart + new Vector3(0, 20f, 0);
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            textObj.rectTransform.localPosition = Vector3.Lerp(fadeOutStart, fadeOutEnd, t / fadeDuration);
            yield return null;
        }

        // Resetar para posição original
        canvasGroup.alpha = 0;
        textObj.rectTransform.localPosition = originalPos;
        textObj.rectTransform.localScale = Vector3.one;
    }
}
