using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    public GameObject[] spawnPoints;
    private int spawnIndex;
    
    public string characterName;
    //private CharacterSelection selectionScript;

    void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnpoint");
        PV = GetComponent<PhotonView>();

        spawnIndex = Random.Range(0, spawnPoints.Length);
        //selectionScript = GameObject.FindObjectOfType<CharacterSelection>();
        //DontDestroyOnLoad(this.gameObject);
        characterName = CharacterSelection.charName;
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
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", characterName), spawnPoints[spawnIndex].transform.position, Quaternion.identity);
    }
}
