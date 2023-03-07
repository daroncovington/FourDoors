using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    private float topSpeed = 450;
    private float topReverseSpeed = 100;
    // public float acceleration;
    private float turnSpeed = 80;
    private float currentSpeed;
    private float gravity = 5;
    public GameObject lights;
    public TMP_Text speedText;
    private GameManager gameManagerCs;
 
    private bool lightToggle;
    private bool isPressed;
    private bool inReverse;
 
    private bool IsPressed
    {
        get { return isPressed; }
        set
        {
            if(value == isPressed)
            {
                return;
            }
 
            isPressed = value;
 
            if(isPressed)
            {
                lightToggle = !lightToggle;
                lights.SetActive(lightToggle);
            }
        }
    }
     
    public float Speed
    {
        get
        {
            return currentSpeed;
        }
    }
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerCs = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
 
    private void Update()
    {
        IsPressed = Input.GetKey(KeyCode.L);
 
        var mph = currentSpeed / 3;
        speedText.text = mph.ToString("F0");
    }
 
    void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;

        if (gameManagerCs.carMenuOpened == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * topSpeed);
                inReverse = false;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -topReverseSpeed);
                inReverse = true;
            }
 
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            localVelocity.x = 0;
            rb.velocity = transform.TransformDirection(localVelocity);
 
            if(rb.velocity.magnitude > topSpeed)
            {
                rb.velocity = rb.velocity.normalized * topSpeed;
            }
            else if (rb.velocity.magnitude > topReverseSpeed && inReverse)
            {
                rb.velocity = rb.velocity.normalized * topReverseSpeed;
            }
 
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddTorque(Vector3.up * turnSpeed * 10);
            } 
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddTorque(-Vector3.up * turnSpeed * 10);
            }
 
            rb.AddForce(Vector3.down * gravity * 10);
        }
    
    }
}
