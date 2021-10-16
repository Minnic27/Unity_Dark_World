using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Rigidbody enemy;
    public Transform spawnPoint;

    private GameUI uiScript;
    private EnemyBehavior enemyScript;

    private int spawnTime;


    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
        enemyScript = GameObject.FindObjectOfType<EnemyBehavior>();

        spawnTime = Random.Range(3, 5);
        StartCoroutine(SpawnToLocation());
    }


    IEnumerator SpawnToLocation()
    {
        while (uiScript.enemiesOnField < uiScript.maxEnemyNumber)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            uiScript.enemiesOnField++;
        }
        
    }

}
