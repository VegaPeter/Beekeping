using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckForCOver : MonoBehaviour
{
    [SerializeField] GameObject beehiveScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            beehiveScript.GetComponent<BeeHiveController>().HiveCoverRemoved();
            Debug.Log("On tha ground");
        }
    }
}
