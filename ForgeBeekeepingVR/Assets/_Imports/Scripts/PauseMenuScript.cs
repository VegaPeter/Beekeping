using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using HurricaneVR.Framework.ControllerInput;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject _Pause_Menu;
    public GameObject _Settings_Menu;

    public Material _Space;
    public Material _Norm;

    bool isActive;
    bool bTimer = false;

    //Peter's Better Way of Coroutines
    float currentTime;
    [SerializeField] float maxTime;
    bool startTimer;

    public void Start()
    {
        //currentTime = maxTime;
        //StartCoroutine(Wait());

        _Pause_Menu.SetActive(false);
        _Settings_Menu.SetActive(false);
        Debug.Log("fU");
    }

    public void Update()
    {
        /*if (HVRGlobalInputs.Instance.LeftMenuButtonState.JustActivated && startTimer == false)
        {
            Debug.Log("pressed");
            //CheckMenuState();
            startTimer = true;
        }
        
        if(currentTime > 0 && startTimer == true) 
        { currentTime -= Time.deltaTime;  
            
        }
        else if(currentTime <=0 && startTimer == true) { }
        {
            currentTime = maxTime;
            startTimer = false;
            //CheckMenuState();
            mPause();
        }
        //mMenuClick();
        Debug.Log(isActive);*/

        mMenuClick();
        mPause();
    }

    private void CheckMenuState()
    {
        if (isActive)
        {

        }
        //isActive = !isActive;
        //startTimer = true;
    }

    private IEnumerator Wait()
    {
        if (isActive && !bTimer)
        {
            yield return new WaitForSeconds(1f) ;
            Debug.Log("waited 1 second");
            bTimer = true ;
        }
        
    }

    //Checking if menu button is clicked
    public void mMenuClick()
    {
        if (HVRGlobalInputs.Instance.LeftMenuButtonState.JustActivated)
        {
            isActive = !isActive;
            Debug.Log("Menu Clicked " + isActive);
        }

        /*if (HVRGlobalInputs.Instance.LeftMenuButtonState.JustActivated)
        {
            Debug.Log("Menu Button Click");
            mPause();

        }
        else if (HVRGlobalInputs.Instance.LeftMenuButtonState.Active)
        {
            _Pause_Menu.SetActive(false);
            _Settings_Menu.SetActive(false);
        }*/

        /*if(isActive && bTimer)
        {
            mPause();
        }
        else
        {
            _Pause_Menu.SetActive(false);
            _Settings_Menu.SetActive(false);
        }*/

    }

    //Onclick Method
    public void mPause()
    {
        //isActive = !isActive;

        if (isActive)
        {
            RenderSettings.skybox = _Space;
            _Pause_Menu.SetActive(true);
            _Settings_Menu.SetActive(false);
        }
        else if (!isActive)        
        {
            mResume();
        }
    }

    //Onclick Method
    public void mResume()
    {
        RenderSettings.skybox = _Norm;
        _Pause_Menu.SetActive(false);
        _Settings_Menu.SetActive(false);
        isActive = false;
        //bTimer = false ;
    }

    //Onclick Method
    public void mRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Onclick Method
    public void mSettings()
    {
        _Pause_Menu.SetActive(false );
        _Settings_Menu.SetActive(true);
    }

    //Onclick Method
    public void mQuit()
    {
        //SceneManager.LoadScene("MainMenu");
        OnApplicationQuit();
    }


    //temp quit
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
