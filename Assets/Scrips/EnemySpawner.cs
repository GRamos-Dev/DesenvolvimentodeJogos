using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesPerWave = 3;
    public float timeBetweenWaves = 10f;
    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while(true)
        {
            currentWave++;
            int enemiesToSpawn = enemiesPerWave + currentWave; // aumenta inimigos a cada wave

            for(int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-4f, 4f), Random.Range(-2f, 2f));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
