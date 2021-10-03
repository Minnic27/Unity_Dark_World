using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public int damage = 1;
    public float range = 100f;

    public float fireRate = 15f;
    public GameObject bulletPrefab;

    public Camera tpsCam;
    
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if(target != null)
        {
            target.TakeDamage(damage);
        }

        GameObject bulletImpact = Instantiate(bulletPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletImpact, 0.5f);
    }

}
