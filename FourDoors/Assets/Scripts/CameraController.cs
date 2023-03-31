using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera coupeCamera;
    public Camera jpCamera;
    private GameManager gameManagerCs;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerCs = GameObject.Find("Game Manager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCs.currentCar == 0)
        {
            coupeCamera.enabled = true;
            jpCamera.enabled = false;
        }
        else if (gameManagerCs.currentCar == 1)
        {
            coupeCamera.enabled = false;
            jpCamera.enabled = true;
        }
    }
}
