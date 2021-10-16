using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private int health = 100;
    public NavMeshAgent enemy;
    private Transform player;
    public Animator anim;
    private float stoppingDistance = 1.8f;
    private bool isAttacking = false;

    //private GameUI uiScript;
    public GameObject rightFist;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        //uiScript = GameObject.FindObjectOfType<GameUI>();
    }

    public void ActivateAttack()
    {
        rightFist.GetComponent<Collider>().enabled = true;
    }

    public void DeactivateAttack()
    {
        rightFist.GetComponent<Collider>().enabled = false;
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    IEnumerator EnemyDie()
    {
        enemy.isStopped = true;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < stoppingDistance)
        {
            isAttacking = true;
            enemy.isStopped = true;
            anim.SetInteger("Attack", 1);
        }
        else
        {
            isAttacking = false;
            enemy.isStopped = false;
            anim.SetInteger("Attack", -1);
            enemy.SetDestination(player.position);
        }

        
        
    }

    void Update()
    {
        FollowPlayer();

        if(health <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(EnemyDie());
        }
        else if(isAttacking && (health <= 0))
        {
            anim.SetTrigger("AttackDeath");
            StartCoroutine(EnemyDie());
        }
    }
}
