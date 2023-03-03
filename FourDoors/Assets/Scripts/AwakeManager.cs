using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    public GameObject toRotate;
    public float rotateSpeed;
    public vehicleList listOfVehicles;
    public int vehiclePointer = 0;

    private void Awake()
    {
        PlayerPrefs.SetInt("pointer",0);
        vehiclePointer = PlayerPrefs.GetInt("pointer");


        GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer],Vector3.zero,Quaternion.identity) as GameObject;
        childObject.transform.parent = toRotate.transform;


    }

    private void FixedUpdate()
    {
        toRotate.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        
    }
}
