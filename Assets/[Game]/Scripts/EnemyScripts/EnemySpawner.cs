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

    [SerializeField] private int enemyCount;

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

                enemyCount++;

                if(enemyCount> 10)

                        yield break;

                Debug.Log("EnemyCount" + enemyCount);


            }
        }
    }

    private void SpawnRandomEnemy(EnemySpawnData spawnData)
    {
        var spawnPoint = spawnData.spawnPoints[Random.Range(0, spawnData.spawnPoints.Length)];
        Instantiate(spawnData.enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}

