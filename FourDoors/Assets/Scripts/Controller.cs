using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField]private driveType drive;

    internal enum gearBox
    {
        automatic,
        manual
    }
    [SerializeField]private gearBox gearChange;

    //other classes ->
    public GameManager manager;

    [Header("Variables")]
    public float totalPower;
    public float maxRPM , minRPM;
    public float KPH;
    public float wheelsRPM;
    public float engineRPM;
    public float[] gears;
    public int gearNum = 0;
    public bool reverse = false;
    public AnimationCurve enginePower;

    private inputManager IM;
    private GameObject wheelMeshes,wheelColliders;
    private wheelCollider[] wheels = new wheelCollider[4];
    private GameObject[] wheelMesh = new GameObject[4];
    private GameObject centerOfMass;
    private Rigidbody rigidbody;

    //hard coded values -

    private float thrust = -20000 , radius = 6, brakPower = 50000 , DownForceValue = 100f;

    [Header("DEBUG")]
    public float[] slip = new float [4];

    private void Awake()
    {
        getObjects();
    }

    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "AwakeScene")return;
        addDownForce();
        animateWheels();
        steerVehicle();
        //getFriction();
        calculateEnginePower();
        shifter();

    }
    private void calculateEnginePower()
    {
        wheelRPM();

        totalPower = enginePower.Evaluate(engineRPM) * (gears[gearNum]) * IM.vertical;
        float velocity = 0.0f;
        engineRPM = Mathf.SmoothDamp(engineRPM,1000 + (Mathf.Abs(wheelsRPM) * 3.6f * (gears[gearNum])), ref velocity , smoothTime);

        moveVehicle();

    }

    private void wheelRpm()
    {
        float sum = 0;
        int R = 0;
        for (int i = 0; i < 4; i++)
        {
            sum += wheels[i].rpm;
            R++;
        }
        wheelsRPM = (R != 0) ? sum / R : 0;


    }

}
