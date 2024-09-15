using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private int enemyLimit = 10;
    [SerializeField] private Transform[] enemies;
    [SerializeField] private float spawnDelay;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);
        if(transform.childCount < enemyLimit)
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(Random.Range(-radius, radius) + transform.position.x, transform.position.y + 5f), transform.rotation, transform);
        StartCoroutine(SpawnEnemies());
    }
}
