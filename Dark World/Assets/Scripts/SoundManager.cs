using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip smgFire, sgFire, pistolFire, arFire, lightOn, lightOff, hitPlayer, enemyAttack, playerDead, reload;
    public static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        smgFire = Resources.Load<AudioClip>("SMG");
        sgFire = Resources.Load<AudioClip>("Shotgun");
        pistolFire = Resources.Load<AudioClip>("Deagle");
        arFire = Resources.Load<AudioClip>("AR1");
        lightOn = Resources.Load<AudioClip>("FlashlightOn");
        lightOff = Resources.Load<AudioClip>("FlashlightOff");
        hitPlayer = Resources.Load<AudioClip>("HitGrunt");
        enemyAttack = Resources.Load<AudioClip>("DemonAttack");
        playerDead = Resources.Load<AudioClip>("DeathGrunt");
        reload = Resources.Load<AudioClip>("Reload");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "SMG":
                audioSrc.PlayOneShot(smgFire);
                break;
            case "Shotgun":
                audioSrc.PlayOneShot(sgFire);
                break;
            case "Deagle":
                audioSrc.PlayOneShot(pistolFire);
                break;
            case "AR1":
                audioSrc.PlayOneShot(arFire);
                break;
            case "FlashlightOn":
                audioSrc.PlayOneShot(lightOn);
                break;
            case "FlashlightOff":
                audioSrc.PlayOneShot(lightOff);
                break;
            case "HitGrunt":
                audioSrc.PlayOneShot(hitPlayer);
                break;
            case "DemonAttack":
                audioSrc.PlayOneShot(enemyAttack);
                break;
            case "DeathGrunt":
                audioSrc.PlayOneShot(playerDead);
                break;
            case "Reload":
                audioSrc.PlayOneShot(reload);
                break;
        }
    }
}
