using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.SharedInstance.GetPooledObject();
        if (enemy != null)
        {
            enemy.transform.position = GenerateSpawnPosition();
            enemy.SetActive(true);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, (Random.Range(-spawnRange, spawnRange)));
    }
}
