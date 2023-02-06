using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    [SerializeField] GameObject honeyInBucket;
    public bool isFilled;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Frame") && isFilled == false)
        {
            FillBucket();
        }
    }

    private void FillBucket()
    {
        honeyInBucket.SetActive(true);
        isFilled = true;
    }

    public void EmptyBucket()
    {
        isFilled = false;
        honeyInBucket.SetActive(false);
    }
}
