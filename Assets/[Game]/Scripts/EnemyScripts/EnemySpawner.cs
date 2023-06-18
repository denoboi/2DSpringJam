using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public Transform spawnPoint;
    }

    public EnemySpawnData[] enemySpawnData;
    public float spawnDistanceThreshold = 6f;
    public float spawnDelay = 5f;

    private Transform player;
    private bool shouldSpawn = true;
    private bool isPlayerNearSpawn = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    private void Update()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (shouldSpawn)
        {
            if (isPlayerNearSpawn)
            {
                SpawnEnemy();
                shouldSpawn = false; // Spawn ettikten sonra spawn işlemi durdurulacak
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        EnemySpawnData spawnData = GetNearestSpawnData();
        if (spawnData != null)
        {
            Instantiate(spawnData.enemyPrefab, spawnData.spawnPoint.position, Quaternion.identity);
        }
    }

    private EnemySpawnData GetNearestSpawnData()
    {
        float nearestDistance = float.MaxValue;
        EnemySpawnData nearestSpawnData = null;

        foreach (EnemySpawnData data in enemySpawnData)
        {
            float distance = Vector3.Distance(data.spawnPoint.position, player.position);
            if (distance <= spawnDistanceThreshold && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestSpawnData = data;
            }
        }

        return nearestSpawnData;
    }

    public void SetPlayerNearSpawn(bool isNear)
    {
        isPlayerNearSpawn = isNear;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetPlayerNearSpawn(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetPlayerNearSpawn(false);
        }
    }
}
