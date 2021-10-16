using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    CharacterController playerController;

    private float walkSpeed = 0.7f;
    private float acceleration = 4.5f;
    private float gravity = -1000.0f;
    Vector3 velocity;
    public Animator anim;
    private SoundManager soundScript;
    private GameUI uiScript;

    public GameObject flashlight;
    private bool isIlluminated;
    public bool isRunning = false;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
        soundScript = GameObject.FindObjectOfType<SoundManager>();
        playerController = GetComponent<CharacterController>();

        if(!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Punch")
        {
            uiScript.DecreaseHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!PV.IsMine)
            return;

            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity = transform.TransformDirection(velocity);

            // diagonal movement check

            if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A))
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D))
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S))
            {
                anim.SetFloat("Movement", 0.67f, 0.1f, Time.deltaTime);
                anim.SetInteger("Strafe", 0);
                velocity *= 0f; 
            }

            else if(Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A))
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if(Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D))
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D))
            {
                anim.SetFloat("Movement", 0.67f, 0.1f, Time.deltaTime);
                anim.SetInteger("Strafe", 0);
                velocity *= 0f;
            }

            // sprinting

            else if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))) 
            {
                // turn off shooting
                isRunning = true;
                anim.SetFloat("Movement", 0f, 0.1f, Time.deltaTime);
                anim.SetInteger("Strafe", 0);
                velocity *= acceleration;   
            }


            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                // turn on shooting
                isRunning = false;
            }


            // WASD movement with animatons

            else if (Input.GetKey(KeyCode.W)) 
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if (Input.GetKey(KeyCode.A)) 
            {
                anim.SetInteger("Strafe", -1);
                velocity *= walkSpeed;
            }

            else if (Input.GetKey(KeyCode.S)) 
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= walkSpeed;
            }

            else if (Input.GetKey(KeyCode.D)) 
            {
                anim.SetInteger("Strafe", 1);
                velocity *= walkSpeed;
            }

            else // to idle animation
            {
                anim.SetFloat("Movement", 0.67f, 0.1f, Time.deltaTime); 
                anim.SetInteger("Strafe", 0);
                velocity *= 0f;
            }

            // toggle flashlight
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(isIlluminated)
                {
                    SoundManager.PlaySound("FlashlightOff");
                    isIlluminated = false;
                    flashlight.SetActive(false);
                }
                else
                {
                    SoundManager.PlaySound("FlashlightOn");
                    isIlluminated = true;
                    flashlight.SetActive(true);
                }
            }

            velocity.y += gravity * Time.deltaTime;
            playerController.Move(velocity * Time.deltaTime);
        

      
    }
}
