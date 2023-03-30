using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePlacerController : MonoBehaviour
{
    [SerializeField] GameObject frameGuide;
    private bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        frameGuide = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Frame"))
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.position = frameGuide.transform.position;
            frameGuide.GetComponent<Renderer>().enabled = false;
            isLocked = true;
        }
    }
}
