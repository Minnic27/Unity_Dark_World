using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 5;


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
}
