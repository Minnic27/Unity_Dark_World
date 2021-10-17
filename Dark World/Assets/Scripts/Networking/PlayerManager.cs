using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    public Transform spawnPoint;

    void Awake()
    {
        spawnPoint = GameObject.FindWithTag("spawnpoint").transform;
        PV = GetComponent<PhotonView>();
    }
   
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bezalel"), spawnPoint.position, Quaternion.identity);
    }
}
