using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject playerHealthBar;
    public GameObject player;
    public GameObject enemy;

     void DestroyGameObject()
    {
        Destroy(Player);

    }
    
    void Start()
    {
        playerHealthBar
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (player collides into enemy)
        
    }
}
