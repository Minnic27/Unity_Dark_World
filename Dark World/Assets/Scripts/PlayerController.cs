using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    CharacterController playerController;

    public float speed = 1.0f;
    public float accelaration = 2.0f;
    public float gravity = -9.0f;
    Vector3 velocity;
    public Animator anim;

    public GameObject flashlight;
    private bool isIlluminated;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) {

            velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            velocity = transform.TransformDirection(velocity);

            // diagonal movement check

            if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A))
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D))
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S))
            {
                velocity *= 0f;
                anim.SetFloat("Movement", 0.5f, 0.1f, Time.deltaTime); 
                anim.SetInteger("Strafe", 0);
            }

            else if(Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A))
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if(Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D))
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D))
            {
                velocity *= 0f;
                // anim.SetFloat("Movement", 0.5f, 0.1f, Time.deltaTime); 
                // anim.SetInteger("Strafe", 0);
            }


            // sprinting

            if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))) 
            {
                anim.SetFloat("Movement", 0f, 0.1f, Time.deltaTime);
                velocity *= accelaration;
            }


            // WASD movement with animatons

            else if (Input.GetKey(KeyCode.W)) 
            {
                anim.SetFloat("Movement", 0.3f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if (Input.GetKey(KeyCode.A)) 
            {
                anim.SetInteger("Strafe", -1);
                velocity *= speed;
            }

            else if (Input.GetKey(KeyCode.S)) 
            {
                anim.SetFloat("Movement", 1f, 0.1f, Time.deltaTime);
                velocity *= speed;
            }

            else if (Input.GetKey(KeyCode.D)) 
            {
                anim.SetInteger("Strafe", 1);
                velocity *= speed;
            }

            else // to idle animation
            {
                anim.SetFloat("Movement", 0.67f, 0.1f, Time.deltaTime); 
                anim.SetInteger("Strafe", 0);
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                if(isIlluminated)
                {
                    isIlluminated = false;
                    flashlight.SetActive(false);
                }
                else
                {
                    isIlluminated = true;
                    flashlight.SetActive(true);
                }
            }
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
