using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private static MusicManager musicManagerInstance;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (musicManagerInstance == null) {
            musicManagerInstance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    
}
