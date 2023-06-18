using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public Transform[] spawnPoints;
        public float spawnInterval;
    }

    public EnemySpawnData[] enemySpawnData;

    private bool shouldSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        foreach (EnemySpawnData data in enemySpawnData)
        {
            while (shouldSpawn)
            {
                yield return new WaitForSeconds(data.spawnInterval);

                SpawnRandomEnemy(data);
            }
        }
    }

    private void SpawnRandomEnemy(EnemySpawnData spawnData)
    {
        var spawnPoint = spawnData.spawnPoints[Random.Range(0, spawnData.spawnPoints.Length)];
        Instantiate(spawnData.enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}

