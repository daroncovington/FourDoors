using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 160;
    private float turnSpeed = 80;
    private float reverseSpeed = 80;
    private float horizontalInput;
    private float verticalInput;
    private bool inForward;
    private bool inReverse;
    private bool turnRight;
    private bool turnLeft;

    private GameObject FLT;
    private GameObject FRT;
    private GameObject BLT;
    private GameObject BRT;

    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        FLT = GameObject.Find("FL_Wheel");
        FRT = GameObject.Find("FR_Wheel");
        BLT = GameObject.Find("RL_Wheel");
        BRT = GameObject.Find("RR_Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(verticalInput >= 0)
        {
            inForward = true;
            inReverse = false;
        }
        else if (verticalInput < 0)
        {
            inForward = false;
            inReverse = true;
        }

        if(horizontalInput > 0)
        {
            turnLeft = false;
            turnRight = true;
        }
        else if(horizontalInput < 0)
        {
            turnLeft = true;
            turnRight = false;
        }

        if(inForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);


        }
       else if(inReverse)
       {
            transform.Translate(Vector3.forward * reverseSpeed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime * horizontalInput);
       }

        
    }
}
