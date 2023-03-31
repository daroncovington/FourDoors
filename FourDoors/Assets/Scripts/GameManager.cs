using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] cars;
    public int currentCar;


 
    public bool inGamePlayScene = false;
     
    // Start is called before the first frame update
    void Start()
    {
        int selectedCar = PlayerPrefs.GetInt("SelectedCarID");
        if (inGamePlayScene == true)
        {
            cars[selectedCar].SetActive(true);
            currentCar = selectedCar;
           
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RightClick()
    {
        if (currentCar < cars.Length)
        {
            currentCar += 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentCar].SetActive(true);
            }
            
        }
        
    }

    public void LeftClick()
    {
        if (currentCar > 0)
        {
            currentCar -= 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentCar].SetActive(true);
            }
        }
    }

    public void CloseCarMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectCar()
    {
        PlayerPrefs.SetInt("SelectedCarID", currentCar);
        SceneManager.LoadScene(1);
    
    }

    public void OpenCarMenu()
    {
        SceneManager.LoadScene(0);
    }

}