using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckForCOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            this.GetComponent<BeeHiveController>().HiveCoverRemoved();
        }
    }
}
