using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public int waveNumber = 1;
    public int enemyCount;
    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();

    }
    private void Update()
    {


        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }

    }
    private void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {

            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(0);
        if (enemy != null)
        {
            enemy.transform.position = GenerateSpawnPosition();
            enemy.SetActive(true);
        }
      
    }
    private void SpawnPowerup(){
        GameObject powerup = ObjectPooler.SharedInstance.GetPooledObject(1);
         if (powerup != null)
        {
            powerup.transform.position = GenerateSpawnPosition();
            powerup.SetActive(true);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, (Random.Range(-spawnRange, spawnRange)));
    }
}
