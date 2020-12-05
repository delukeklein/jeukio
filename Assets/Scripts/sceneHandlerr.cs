using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneHandler : MonoBehaviour
{
    [Header("Scene Name")]
    public string sceneName = "";

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);

    }
}
