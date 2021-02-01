using UnityEngine;

using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("GO")]
    public GameObject set;
    public GameObject FPSCounter;

    [Header("Settings")]
    public bool ShowSettings = false;
    public Toggle FPSToggle;

    public void Settings()
    {
        ShowSettings = true;
        set.SetActive(true);
    }
    public void FPS()
    {
        FPSCounter.SetActive(FPSToggle.isOn);
    }

    public void Close()
    {
        ShowSettings = false;
        set.SetActive(false);
        Time.timeScale = 1f;
        print(Time.timeScale);
    }
    public void Close1()
    {
        ShowSettings = false;
        set.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}