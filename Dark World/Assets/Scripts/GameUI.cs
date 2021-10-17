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
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        healthUI.text = "Health: " + playerHealth + "%";
    }

    public void DecreaseHealth()
    {
        if(playerHealth > 20)
        {
            SoundManager.PlaySound("HitGrunt");
            playerHealth -= 20;
            healthUI.text = "Health: " + playerHealth + "%";
        }
        else
        {
            SoundManager.PlaySound("DeathGrunt");
            playerHealth = 0;
            healthUI.text = "Health: " + playerHealth + "%";
            StartCoroutine(DeathSequence());
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

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Player is DEAD!");
        Time.timeScale = 0;
    }
}
