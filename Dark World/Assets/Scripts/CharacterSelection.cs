using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    
    private PlayerManager pmScript;


    void Start()
    {
        Debug.Log(characters[selectedCharacter].name);
        pmScript = GameObject.FindObjectOfType<PlayerManager>();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        Debug.Log(characters[selectedCharacter].name);
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
        Debug.Log(characters[selectedCharacter].name);
    }

    public void SelectCharacter()
    {
        pmScript.characterName = characters[selectedCharacter].name;
        //PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        //SceneManager.LoadScene("Neighborhood");
        //Debug.Log(characterName);
    }
}
