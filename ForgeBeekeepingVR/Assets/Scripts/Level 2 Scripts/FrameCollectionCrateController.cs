using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCollectionCrateController : MonoBehaviour
{
    [SerializeField] int framesCompleted = 0;
    [SerializeField] List<GameObject> framesReadyForTransport = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Frame"))
        {
            Destroy(other.gameObject);
            framesCompleted++;

            framesReadyForTransport[framesCompleted - 1].SetActive(true);

            if(framesCompleted == 3)
            {
                AllFramesLoaded();
            }
        }
    }

    void AllFramesLoaded()
    {
        Debug.Log("Level completed");
    }
}
