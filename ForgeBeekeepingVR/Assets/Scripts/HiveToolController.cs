using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveToolController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Frame"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hive frame loosened");
        }
    }
}
