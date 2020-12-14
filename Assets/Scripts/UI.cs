using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("GO")]
    public GameObject set;
    public GameObject FPSCounter;

    [Header("Settings")]
    public bool ShowSettings = false;
    public Toggle FPSToggle;


    [SerializeField] private Component[] components;

  
    public void Settings()
    {
        ShowSettings = true;
        if (ShowSettings == true)
        {
            set.SetActive(true);
        }
    }
    public void FPS()
    {
        if(FPSToggle.isOn == true)
        {
            FPSCounter.SetActive(true);
        }
        else if (FPSToggle.isOn == false)
        {
            FPSCounter.SetActive(false);
        }
    }
    public void Close()
    {
        ShowSettings = false;
        if (ShowSettings == false)
        {
            set.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
        print("quit");
    }


    
   
}
