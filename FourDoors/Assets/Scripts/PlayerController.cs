using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public float topSpeed;
    // public float acceleration;
    public float turnSpeed;
    private float currentSpeed;
    public float gravity;
    public GameObject lights;
    public TMP_Text speedText;
 
    public bool lightToggle;
    private bool isPressed;
 
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
    }
 
    private void Update()
    {
        IsPressed = Input.GetKey(KeyCode.L);
 
        var mph = currentSpeed * 2.237f;
        speedText.text = mph.ToString("F0");
    }
 
    void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;
 
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * topSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -topSpeed * 0.25f);
        }
 
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
 
        if(rb.velocity.magnitude > topSpeed)
        {
            rb.velocity = rb.velocity.normalized * topSpeed;
        }
 
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 10);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed * 10);
        }
 
        rb.AddForce(Vector3.down * gravity * 10);
    }
}
