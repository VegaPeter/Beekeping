using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.Utils;
using HurricaneVR.Framework.Shared;
using HurricaneVR.Framework.ControllerInput;
using Oculus.Interaction;

public class SmokerController : MonoBehaviour
{
    [SerializeField] Collider smokerCollider;
    [SerializeField] HVRPlayerInputs playerRig;
    [SerializeField] ParticleSystem passiveSmoke, activeSmoke;
    bool isHeld, isLit;

    public bool IsLit { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (isLit)
        {
            passiveSmoke.Play();

            //Checks to see if isHeld is true (isHeld is set when the smoker is picked up) and then if either trigger is held.
            if (isHeld && ((playerRig.IsLeftTriggerHoldActive == true && playerRig.IsLeftGripHoldActive) || (playerRig.IsRightTriggerHoldActive == true && playerRig.IsRightGripHoldActive)))
            {
                passiveSmoke.Stop();
                activeSmoke.Play();
                smokerCollider.enabled = true;
            }
            else
            {
                Debug.Log("Conditions not met");
                passiveSmoke.Play();
                activeSmoke.Stop();
                smokerCollider.enabled = false;
            }
        }
        else
        {
            passiveSmoke.Stop();
            activeSmoke.Stop();
        }
    }

    //Sets the isHeld variable to what it is currently not, isHeld is initialised as false
    public void SmokerIsHeld()
    {
        isHeld = !isHeld;
        Debug.Log("isHeld: " + isHeld);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BeeSwarm"))
        {
            other.gameObject.GetComponent<BeeHiveController>().BeeAgressionManager(0);

            Debug.Log("Smoking Bees");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BeeSwarm"))
        {
            //Debug.Log("Bees Raging");
        }
    }

    public void LightSmoker()
    {
        isLit = !isLit;
    }
}
