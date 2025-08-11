using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;    // Prefab do inimigo
    public Transform player;          // Referência ao jogador
    public int enemiesPerWave = 3;    // Quantidade de inimigos por onda
    public float timeBetweenWaves = 10f;  // Tempo entre ondas
    public float spawnRadiusMin = 3f;     // Distância mínima do player para spawn
    public float spawnRadiusMax = 7f;     // Distância máxima do player para spawn

    private int currentWave = 0;

    void Awake()
    {
        // Fallback: tenta achar o player por tag se não foi atribuído
        if (player == null)
        {
            var go = GameObject.FindWithTag("Player");
            if (go != null) player = go.transform;
        }
    }

    void Start()
    {
        if (player == null)
        {
            Debug.LogWarning("EnemySpawner: Player não atribuído. Vou tentar encontrar quando o Player aparecer.");
            StartCoroutine(WaitForPlayerThenStart());
            return;
        }
        StartCoroutine(SpawnWaves());
    }

    IEnumerator WaitForPlayerThenStart()
    {
        while (player == null)
        {
            var go = GameObject.FindWithTag("Player");
            if (go != null) player = go.transform;
            yield return null;
        }
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;
            int enemiesToSpawn = enemiesPerWave + currentWave; // aumenta inimigos a cada wave

            Debug.Log("Iniciando wave " + currentWave);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemyNearPlayer();
                yield return new WaitForSeconds(1f); // espaçamento entre spawns
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemyNearPlayer()
    {
        if (player == null) return;

        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        float spawnDistance = Random.Range(spawnRadiusMin, spawnRadiusMax);
        Vector2 spawnPos = (Vector2)player.position + spawnDirection * spawnDistance;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Spawn de inimigo perto do player em: " + spawnPos);
    }

    // Permite setar o player em runtime (se for instanciado depois)
    public void SetPlayer(Transform t)
    {
        player = t;
    }
}