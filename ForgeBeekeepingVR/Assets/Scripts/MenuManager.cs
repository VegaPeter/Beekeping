using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject inGamecanvas;

    public void QuitApp()
    {
       Application.Quit();
    }

    public void StartApp()
    {
        SceneManager.LoadScene("Forest Demo Scene 1");
    }
}
