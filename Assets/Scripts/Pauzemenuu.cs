using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauzemenuu : MonoBehaviour
{
    public bool gameisPaused = false;

    //public Camera CS;
    public GameObject PM;
    public GameObject DeathScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        gameisPaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;

        if (gameisPaused == true)
        {
            PM.SetActive(true);

           // CS.enabled = false;
        }
    }

    public void Resume()
    {
        gameisPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;

        if (gameisPaused == false)
        {
            PM.SetActive(false);
           // CS.enabled = true;
        }
    }

    public void death()
    {
        DeathScreen.SetActive(true);
        Cursor.visible = true;
    }
}
