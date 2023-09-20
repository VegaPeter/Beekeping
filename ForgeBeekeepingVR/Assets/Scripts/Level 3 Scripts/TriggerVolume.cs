using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] GameObject _internalPlayer, _externalPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FrameCrate"))
        {
            _externalPlayer.SetActive(false);
            _internalPlayer.SetActive(true);
        }
    }
}
