using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Rigidbody enemy;
    public Transform spawnPoint;

    private int enemySpawned;
    private int spawnTime;


    void Start()
    {
        spawnTime = Random.Range(3, 5);
        StartCoroutine(SpawntoLocation());
    }


    IEnumerator SpawntoLocation()
    {
        while (enemySpawned < 1)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            enemySpawned++;
        }
        
    }
}
