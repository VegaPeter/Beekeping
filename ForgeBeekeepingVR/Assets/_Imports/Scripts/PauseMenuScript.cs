using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject _Pause_Menu;
    public GameObject _Settings_Menu;

    public Material _Space;
    public Material _Norm;

    public void mPause()
    {
        RenderSettings.skybox = _Space;
        _Pause_Menu.SetActive(true);
    }

    public void mResume()
    {
        RenderSettings.skybox = _Norm;
        _Pause_Menu.SetActive(false);
    }

    public void mRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mSettings()
    {
        _Pause_Menu.SetActive(false );
        _Settings_Menu.SetActive(true);
    }

    public void mQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
