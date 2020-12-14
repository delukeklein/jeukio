﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauzemenuu : MonoBehaviour
{
    public bool gameisPaused = false;

    public FpsControllerLPFP PC;
    public GameObject PM;
    public GameObject DeathScreen;

    [SerializeField] private Health health;

    private bool isDead = false;

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

        if (health.health <= 0 && !isDead)
        {
            death();

            isDead = true;
        }
    }

    public void Pause()
    {
        gameisPaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;

        if (gameisPaused == true)
        {
            PM?.SetActive(true);

            PC.enabled = false;

            //Playeroff.SetActive(false);

            //foreach (var component in disableComponents)
            //{
            //    component.enabled = false;
            //}
        }
    }

    public void Resume()
    {
        gameisPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;

        if (gameisPaused == false)
        {
            PM?.SetActive(false);

            PC.enabled = true;

            // Playeroff.SetActive(true);


            //foreach (var component in disableComponents)
            //{
            //    component.enabled = true;
            //}
        }
    }

    public void death()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
