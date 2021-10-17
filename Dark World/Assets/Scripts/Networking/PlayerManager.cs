using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    public Transform spawnPoint;
    public string characterName;

    void Awake()
    {
        spawnPoint = GameObject.FindWithTag("spawnpoint").transform;
        PV = GetComponent<PhotonView>();

        if(characterName == "")
        {
            characterName = "Kyrilios";
        }
        
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", characterName), spawnPoint.position, Quaternion.identity);
    }
}
