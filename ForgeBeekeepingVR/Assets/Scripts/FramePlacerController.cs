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

            other.gameObject.transform.localPosition = frameGuide.transform.position;
            other.gameObject.transform.localRotation = frameGuide.transform.rotation;

            other.gameObject.GetComponentInChildren<Transform>().localPosition = new Vector3(0f, 0f, 0f);
            other.gameObject.GetComponentInChildren<Transform>().localRotation = Quaternion.Euler(0f, 0f, 0f);


            frameGuide.GetComponent<Renderer>().enabled = false;
            frameGuide.GetComponentInChildren<Renderer>().enabled = false;

            isLocked = true;
        }
    }
}
