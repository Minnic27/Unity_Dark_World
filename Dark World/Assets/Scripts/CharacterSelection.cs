using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;

    //public GameObject objPrefab;
    public static string charName;
    public PlayerManager pmScript;

    void Start()
    {
        //objPrefab = GameObject.FindGameObjectWithTag("PlayerManager");
        pmScript = GameObject.FindObjectOfType<PlayerManager>();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void SelectCharacter()
    {
        charName = characters[selectedCharacter].name;
    }
}
