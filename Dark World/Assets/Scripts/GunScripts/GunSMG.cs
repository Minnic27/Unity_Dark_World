using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSMG : MonoBehaviour
{
    public int damage = 10;
    private float range = 100f;
    public int ammo = 50;

    private float fireRate = 15f;
    
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Camera tpsCam;
    
    private float nextTimeToFire = 0f;
    public PlayerController playerScript;
    private GameUI uiScript;


    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
        uiScript.ammoUI.text = "Ammo: " + ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            
            if(!playerScript.isRunning)
            {
                if(ammo <= 0)
                {
                    uiScript.ammoUI.text = "Press 'R' to reload";
                }
                else
                {
                    Shoot();
                }
                
            }
        }

        GunReload();
    }

    void Shoot()
    {
        muzzleFlash.Play();
        SoundManager.PlaySound("SMG");
        RaycastHit hit;
        
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyBehavior target = hit.transform.GetComponent<EnemyBehavior>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }  
        }

        

        GameObject bulletImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletImpact, 0.5f);
        ammo--;
        uiScript.ammoUI.text = "Ammo: " + ammo;
    }

    public void GunReload()
    {
        if ((Input.GetKey(KeyCode.R)) && (ammo == 0)) // checks if gun is out of ammo
        {
            ammo = 50;
            uiScript.ammoUI.text = "Ammo: " + ammo;
            SoundManager.PlaySound("Reload");
        }
    }
}
