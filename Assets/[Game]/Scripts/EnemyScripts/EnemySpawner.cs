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
        public float spawnRate;
    }

    public EnemySpawnData[] enemySpawnData;

    private void Start()
    {
        foreach (EnemySpawnData data in enemySpawnData)
        {
            StartCoroutine(SpawnEnemies(data));
        }
    }

    private IEnumerator SpawnEnemies(EnemySpawnData spawnData)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnData.spawnRate);

            var spawnPoint = spawnData.spawnPoints[Random.Range(0, spawnData.spawnPoints.Length)];
            Instantiate(spawnData.enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
