using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text ammoUI;
    public Text healthUI;
    public int playerHealth = 100;
    public Text timerUI;

    private float startTime;
    private string minutes;
    private string seconds;
    private string totalTime;

    [HideInInspector]
    public int enemiesOnField;
    
    public int maxEnemyNumber = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        healthUI.text = "Health: " + playerHealth + "%";
    }

    public void DecreaseHealth()
    {
        playerHealth -= 20;
        healthUI.text = "Health: " + playerHealth + "%";

        if(playerHealth <= 0)
        {
            playerHealth = 0;
            healthUI.text = "Health: " + playerHealth + "%";
        }
    }

    public void UpdateTime()
    {
        float t = Time.time - startTime;

        minutes = ((int) t / 60).ToString();
        seconds  = (t % 60).ToString("f1");
        timerUI.text ="Time Survived: " + minutes + ":" + seconds;
        totalTime = minutes + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
}
