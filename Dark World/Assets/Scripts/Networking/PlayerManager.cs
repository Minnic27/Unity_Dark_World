using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    public Transform spawnPoint;
    
    private CharacterSelection selectionScript;

    void Awake()
    {
        spawnPoint = GameObject.FindWithTag("spawnpoint").transform;
        PV = GetComponent<PhotonView>();

        selectionScript = GameObject.FindObjectOfType<CharacterSelection>();
        
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Kyrilios"), spawnPoint.position, Quaternion.identity);
    }
}
