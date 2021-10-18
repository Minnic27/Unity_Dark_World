using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class EnemyBehavior : MonoBehaviour
{
    private int health = 100;
    public NavMeshAgent enemy;
    public GameObject[] players;
    public Animator anim;
    private float stoppingDistance = 1.8f;
    private bool isAttacking = false;

    private GameUI uiScript;
    public GameObject rightFist;

    private float DistanceFromLastTarget;
    private int MainTarget;
    private float distance;
    private float DistanceFromTarget;  

    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }    

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        uiScript = GameObject.FindObjectOfType<GameUI>();
    }

    public void ActivateAttack()
    {
        rightFist.GetComponent<Collider>().enabled = true;
        SoundManager.PlaySound("DemonAttack");
    }

    public void DeactivateAttack()
    {
        rightFist.GetComponent<Collider>().enabled = false;
    }

    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    public IEnumerator EnemyDie()
    {
        enemy.isStopped = true;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
        
    }

    private void FollowPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        //Target.size returns the size of the array//
        {
            if (players[i] != null)
            //Makes sure it's following a living target, I recommend creating a boolean inside the target to check if it's dead or not and referecing it here//
            {
                distance = Vector3.Distance(transform.position, players[i].transform.position);
    
                if (i > 0)
                //Never let a script try to grab info from a null element from an array/list, as this creates an error. This makes sure it doesn't take information from Target[-1]//
                {
                    DistanceFromLastTarget = Vector3.Distance (players[i - 1].transform.position, transform.position);
                }
                else
                {
                    DistanceFromLastTarget = 1.8f;
                }
    
                if (DistanceFromTarget > DistanceFromLastTarget)
                {
                    MainTarget = i;
                }
            }
        }
        
        //float distance = Vector3.Distance(transform.position, players[i].transform.position);

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
            enemy.SetDestination(players[MainTarget].transform.position);
        }

        
        
    }

    void Update()
    {
        if(!PV.IsMine)
            return;

        FollowPlayer();

        if(health <= 0)
        {
            anim.SetInteger("Attack", 0);
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
