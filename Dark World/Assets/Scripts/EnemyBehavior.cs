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
    private float stoppingDistance = 2.3f;


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    IEnumerator EnemyDie()
    {
        anim.SetTrigger("Death");
        enemy.isStopped = true;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < stoppingDistance)
        {
            enemy.isStopped = true;
            //anim.SetInteger("Attack", 1);
        }
        else
        {
            enemy.isStopped = false;
            //anim.SetInteger("Attack", -1);
            enemy.SetDestination(player.position);
        }

        
        
    }

    void Update()
    {
        FollowPlayer();

        if(health <= 0)
        {
            StartCoroutine(EnemyDie());
        }
    }
}
