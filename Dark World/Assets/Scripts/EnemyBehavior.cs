using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private int health = 5;

    public NavMeshAgent enemy;
    public Transform player;


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Hit");

        if(health <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
    }

    private void FollowPlayer()
    {
        enemy.SetDestination(player.position);
    }

    void Update()
    {
        FollowPlayer();
    }
}
