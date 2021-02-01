using DesertStormZombies.Entity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauzemenuu : MonoBehaviour
{
    public bool gameisPaused = false;

    public GameObject PM;

    public GameObject player;
    public GameObject camera2;
    
    [SerializeField] private Health health;

    private bool isDead = false;

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

        if (health.isDepleted && !isDead)
        {
            death();

            isDead = true;
        }
    }

    public void Pause()
    {
        gameisPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        if (gameisPaused == true)
        {
            PM.SetActive(true);
            player.SetActive(false);
            camera2.SetActive(true);
        }
        Time.timeScale = 0f;
        print(Time.timeScale);

    }

    public void Resume()
    {
        gameisPaused = false;
        Cursor.visible = false;

        if (gameisPaused == false)
        {
            PM.SetActive(false);
            player.SetActive(true);
            camera2.SetActive(false);

        }
        Time.timeScale = 1f;
        print(Time.timeScale);

    }

    public void death()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
