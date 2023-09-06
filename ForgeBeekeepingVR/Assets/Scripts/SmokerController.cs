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
    [SerializeField] Animator _smokerAnimator;
    bool isHeld = false;
    [SerializeField] bool isLit = false; //defaulted isLit to true for now

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
                _smokerAnimator.SetBool("BellowSqueezed", true);
                passiveSmoke.Stop();
                activeSmoke.Play();
                smokerCollider.enabled = true;
            }
            else
            {
                _smokerAnimator.SetBool("BellowSqueezed", false);
                passiveSmoke.Play();
                activeSmoke.Stop();
                smokerCollider.enabled = false;
            }
        }
    }

    //Sets the isHeld variable to what it is currently not, isHeld is initialised as false
    public void SmokerIsHeld()
    {
        isHeld = !isHeld;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BeeSwarm"))
        {
            other.gameObject.GetComponentInParent<BeeHiveController>().BeeAgressionManager(0);
        }
        else if(other.CompareTag("Kindling"))
        {
            PrepareSmoker();
            other.gameObject.SetActive(false);
        }
    }

    void LightSmoker()
    {
        isLit = true;

        //passiveSmoke.Play();
        _smokerAnimator.SetBool("SmokerPrepared", true);
    }

    public void PrepareSmoker()
    {
        _smokerAnimator.SetBool("PreparingSmoker", true);
    }

    public void SmokerPrepared()
    {
        _smokerAnimator.SetBool("PreparingSmoker", false);
        LightSmoker();
    }
}
