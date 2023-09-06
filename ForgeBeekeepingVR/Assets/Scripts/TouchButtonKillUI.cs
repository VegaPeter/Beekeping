using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchButtonKillUI : MonoBehaviour
{
    [SerializeField] GameObject _thisUI;
    [SerializeField] TutorialActiveController _activeController;

    private void Awake()
    {
        _thisUI = this.gameObject;
        _activeController = this.GetComponentInParent<TutorialActiveController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _activeController.SetNextTutorialActive();
            _thisUI.gameObject.SetActive(false);
        }
    }
} 
