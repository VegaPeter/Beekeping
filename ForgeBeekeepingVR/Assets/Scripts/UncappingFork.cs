using HurricaneVR.Framework.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncappingFork : MonoBehaviour
{
    ParticleSystem honeyDrip;
    //GameObject cappedComb;
    //GameObject[] potentialComb;
    [HideInInspector] public bool uncappedHoneyFromFrame;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("CappedHoney"))
    //    {
    //        //Swap Comb to Uncapped
    //            //-Creates an array of potential capped combs
    //            //-Searches through each candidate until it finds a suitable one
    //            //-Sets suitable candidate to gameobject so as to be disabled, revealing uncapped comb
    //        potentialComb = other.gameObject.GetComponentsInChildren<GameObject>();

    //        for (int i = 0; i < potentialComb.Length; i++)
    //        {
    //            if (potentialComb[i].CompareTag("CappedHoney"))
    //            {
    //                cappedComb = potentialComb[i];
    //                cappedComb.SetActive(false);
    //                break;
    //            }
    //        }

    //        //Spawn Honey Particle System
    //        honeyDrip = other.gameObject.GetComponent<ParticleSystem>();
    //        honeyDrip.Play();

    //        //Set variable to true for any referencing
    //        uncappedHoneyFromFrame = true;
    //    }
    //}

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
