using HurricaneVR.Framework.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncappingFork : MonoBehaviour
{
    ParticleSystem honeyDrip; 
    [HideInInspector] public bool uncappedHoneyFromFrame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CappedHoney"))
        {
            other.gameObject.GetComponent<Renderer>().enabled = false;
            //Allows the frame to enter the strainer
            other.gameObject.GetComponentInParent<GameObject>().tag = "NoFrameNoStrain";

            //Spawn Honey Particle System
            honeyDrip = other.gameObject.GetComponent<ParticleSystem>();
            honeyDrip.Play();
        }
    }
}
