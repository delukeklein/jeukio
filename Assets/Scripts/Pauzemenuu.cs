using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauzemenuu : MonoBehaviour
{
    public bool gameisPaused = false;


    public GameObject PM;
    public GameObject DeathScreen;

    [Header("Disable Components")]
    // [SerializeField] GameObject Playeroff;
    [SerializeField] private MonoBehaviour[] disableComponents;

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

            //Playeroff.SetActive(false);

            foreach (var component in disableComponents)
            {
                component.enabled = false;
            }
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

            // Playeroff.SetActive(true);


            foreach (var component in disableComponents)
            {
                component.enabled = true;
            }
        }
    }

    public void death()
    {
        DeathScreen.SetActive(true);
        Cursor.visible = true;
        print("Death");
    }
}
