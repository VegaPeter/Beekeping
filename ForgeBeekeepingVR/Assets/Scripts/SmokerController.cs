using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.Utils;
using HurricaneVR.Framework.Shared;
using Oculus.Interaction;

public class SmokerController : MonoBehaviour
{
    [SerializeField] GameObject smokeParticleSystem;
    [SerializeField] Collider smokerCollider;
    bool isHeld;

    // Update is called once per frame
    void Update()
    {
        //Checks to see if isHeld is true (isHeld is set when the smoker is picked up) and then if either trigger is held.
        //Note: will work if the smoker is in the left hand but the right trigger is held
        if(isHeld && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 1.0f || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 1.0f))
        {
            smokeParticleSystem.SetActive(true);
            smokerCollider.enabled = true;
        }
        else if (smokeParticleSystem.activeSelf == true)
        {
            Debug.Log("Conditions not met");
            smokeParticleSystem.SetActive(false);
            smokerCollider.enabled = false;
        }
    }

    //Sets the isHeld variable to what it is currently not, isHeld is initialised as false
    public void SmokerIsHeld()
    {
        if (isHeld) { isHeld = false; }
        else if (isHeld == false) { isHeld = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BeeSwarm"))
        {
            Debug.Log("Smoking Bees");

            ParticleSystem ps = other.GetComponentInChildren<ParticleSystem>();
            var main = ps.main;

            main.maxParticles = 50;

            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.volume -= 0.1f;

        }
    }
}
