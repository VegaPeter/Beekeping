using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePlacerController : MonoBehaviour
{
    [SerializeField] GameObject frameGuide, frameGuideChild;
    [SerializeField] GameObject placedFrameForUncapping;
    private bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        frameGuide = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frame"))
        {
            //Next Version Of This Fucking Method
            frameGuide.gameObject.GetComponent<Renderer>().enabled = false;
            frameGuideChild.gameObject.GetComponent<Renderer>().enabled = false;

            placedFrameForUncapping.SetActive(true);
            Destroy(other.gameObject);


        }
    }
}
