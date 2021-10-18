using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class SpawnEnemy : MonoBehaviour
{
    public Rigidbody enemy;
    public Transform spawnPoint;

    private int spawnTime;
    private bool stop;

    PhotonView PV;
    
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        spawnTime = Random.Range(3, 5);

        if(PV.IsMine)
        {
            StartCoroutine(SpawnToLocation());
        }
        
    }


    IEnumerator SpawnToLocation()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(spawnTime);
            //Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Aswang"), spawnPoint.position, spawnPoint.rotation);
        }
        
    }

}
