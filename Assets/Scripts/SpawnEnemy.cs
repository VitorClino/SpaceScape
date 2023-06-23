using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawnRate = 1f;
    public float spawnRadius = 5f;
    public GameObject enemyPrefab;
    //public float limiteDeInimigos = 10f;
    //float numeroDeInimigos = 0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        enemyPrefab.SetActive(true);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5f/spawnRate);
        }
        
    }
}