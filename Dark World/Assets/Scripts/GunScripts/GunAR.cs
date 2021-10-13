using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAR : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;

    public float fireRate = 15f;
    
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Camera tpsCam;
    
    private float nextTimeToFire = 0f;
    public PlayerController playerScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            
            if(!playerScript.isRunning)
            {
                Shoot();
            }
            
            
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        SoundManager.PlaySound("AR(1)");
        RaycastHit hit;
        
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

        EnemyBehavior target = hit.transform.GetComponent<EnemyBehavior>();
        if(target != null)
        {
            target.TakeDamage(damage);
        }

        GameObject bulletImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletImpact, 0.5f);
    }
}
