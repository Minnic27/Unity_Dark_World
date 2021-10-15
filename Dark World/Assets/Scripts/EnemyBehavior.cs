using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private int health = 100;
    public NavMeshAgent enemy;
    public Transform player;
    public Animator anim;
    private bool isAlive;


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            isAlive = false;
            StartCoroutine(EnemyDie());
        }
    }

    IEnumerator EnemyDie()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void FollowPlayer()
    {
        if(isAlive)
        {
            enemy.SetDestination(player.position);
        }
        
    }

    void Update()
    {
        FollowPlayer();   
    }
}
