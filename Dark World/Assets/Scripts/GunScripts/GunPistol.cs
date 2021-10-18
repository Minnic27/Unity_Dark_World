using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunPistol : MonoBehaviourPunCallbacks
{
    public int damage = 25;
    private float range = 100f;
    public int ammo = 10;

    private float fireRate = 2f;
    
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Camera tpsCam;
    
    private float nextTimeToFire = 0f;
    public PlayerController playerScript;
    private GameUI uiScript;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
        uiScript.ammoUI.text = ammo + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        if(!PV.IsMine)
            return;

        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            
            if(!playerScript.isRunning)
            {
                if(ammo <= 0)
                {
                    uiScript.ammoUI.text = "'R' to Reload";
                }
                else
                {
                    //Shoot();
                    photonView.RPC("Shoot", RpcTarget.All);
                }
            }
        }

        GunReload();
    }
    [PunRPC]
    void Shoot()
    {
        muzzleFlash.Play();
        SoundManager.PlaySound("Deagle");
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
        uiScript.ammoUI.text = ammo + "/10";
    }

    public void GunReload()
    {
        if ((Input.GetKey(KeyCode.R)) && (ammo == 0)) // checks if gun is out of ammo
        {
            ammo = 10;
            uiScript.ammoUI.text = ammo + "/10";
            SoundManager.PlaySound("Reload");
        }
    }
}
