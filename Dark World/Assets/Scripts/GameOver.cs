using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text timerScore;
    public static string timerScoreString;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        timerScore.text = timerScoreString;
    }

    public void LeaveRoom()
    {
        //PhotonNetwork.LeaveRoom();
        //SceneManager.LoadScene("MainMenu");
        //MenuManager.Instance.OpenMenu("loading");

        Application.Quit();
    }
}
