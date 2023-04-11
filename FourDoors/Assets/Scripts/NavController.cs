using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour
{
    public NavMeshAgent carAgent;
    public GameObject target;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        carAgent = GameObject.Find("vehicle2-blue").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        destination = target.transform.position;
        if(Input.GetMouseButtonDown(1))
        {
            carAgent.SetDestination(destination);
        }
    }
}
