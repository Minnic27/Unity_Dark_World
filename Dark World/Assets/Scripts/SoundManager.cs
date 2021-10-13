using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip smgFire, sgFire, pistolFire, arFire;
    [SerializeField] AudioClip[] footsteps;
    public static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        int footstepIndex = Random.Range(0, footsteps.Length);

        smgFire = Resources.Load<AudioClip>("SMG");
        sgFire = Resources.Load<AudioClip>("Shotgun");
        pistolFire = Resources.Load<AudioClip>("Deagle");
        arFire = Resources.Load<AudioClip>("AR(1)");

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
            case "AR(1)":
                audioSrc.PlayOneShot(arFire);
                break;
        }
    }

    public void FootStep()
    {
        AudioClip clip = GetRandomSFX();
        audioSrc.PlayOneShot(clip);
    }

    public AudioClip GetRandomSFX()
    {
        int index = Random.Range(0, footsteps.Length - 1);
        return footsteps[index];
    }
}
