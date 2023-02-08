using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameGripController : MonoBehaviour
{
    public bool frameGrabbed, frameToolHeld;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HiveFrame"))
        {
            other.GetComponent<GameObject>().transform.parent = this.transform;
            frameGrabbed = true;
        }
    }

    public void FrameToolHeldController()
    {
        frameToolHeld = !frameToolHeld;
    }
}
