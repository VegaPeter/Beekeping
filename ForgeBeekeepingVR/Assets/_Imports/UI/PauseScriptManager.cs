using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScriptManager : MonoBehaviour
{
    public GameObject Pause_Menu;
    public string SceneName;


    public void PauseGame()
    {
        Time.timeScale = 0;        
        Pause_Menu.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause_Menu.SetActive(false);
    }

    public void Settings()
    {
        Pause_Menu.SetActive(false);

    }


    public void Restart()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
