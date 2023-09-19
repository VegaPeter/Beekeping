using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINavScript : MonoBehaviour
{
    private Button uResume;
    private Button uRestart;
    private Button uSettings;
    private Button uQuit;

    [SerializeField] GameObject resumeBTN;
    [SerializeField] GameObject restartBTN;
    [SerializeField] GameObject settingsBTN;
    [SerializeField] GameObject quitBTN;

    private void Awake()
    {
        uResume = resumeBTN.GetComponent<Button>();
        uRestart = restartBTN.GetComponent<Button>();
        uSettings = settingsBTN.GetComponent<Button>();
        uQuit = quitBTN.GetComponent<Button>();

        uResume.onClick.AddListener(MethodName);
        uRestart.onClick.AddListener(MethodName);
        uSettings.onClick.AddListener(MethodName);
        uQuit.onClick.AddListener(MethodName);
    }

    private void MethodName()
    {

    }
}
