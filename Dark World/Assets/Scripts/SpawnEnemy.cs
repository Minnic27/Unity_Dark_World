using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Rigidbody enemy;
    public Transform spawnPoint;

    private int spawnTime;
    private bool stop;


    void Start()
    {
        spawnTime = Random.Range(3, 5);
        StartCoroutine(SpawnToLocation());
    }


    IEnumerator SpawnToLocation()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
        
    }

}
