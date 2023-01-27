using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameGripController : MonoBehaviour
{
    public bool frameGrabbed, frameToolHeld;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
