using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 60;
    private float turnSpeed = 80;
    private float reverseSpeed = 30;
    private float horizontalInput;
    private float verticalInput;
    public bool inForward;
    public bool inReverse;

    private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(verticalInput > 0)
        {
            inForward = true;
            inReverse = false;
        }
        else if (verticalInput < 0)
        {
            inForward = false;
            inReverse = true;
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
