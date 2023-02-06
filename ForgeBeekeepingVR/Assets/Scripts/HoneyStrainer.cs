using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyStrainer : MonoBehaviour
{
    private bool filledWithUnstrainedHoney,strainedHoney;

    [SerializeField] private GameObject honeyInStrainer;
    [SerializeField] private GameObject honeyForSale;
    private BucketController bucketController;

    public void StartStrainer()
    {
        if (filledWithUnstrainedHoney)
        {
            StartCoroutine(StrainingHoney());
        }
        else
        {
            Debug.Log("Not filled with honey");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("HoneyBucket"))
        {
            honeyInStrainer.SetActive(true);
            bucketController = other.GetComponent<BucketController>();

            while(honeyInStrainer.transform.position.y <= 5f)
            {
                honeyInStrainer.transform.position += new Vector3(0, .3f, 0);
            }
            Debug.Log("Filled with honey");

            filledWithUnstrainedHoney = true;
            bucketController.EmptyBucket();
        }
    }

    private IEnumerator StrainingHoney()
    {
        yield return new WaitForSeconds(45);
        strainedHoney = true;
        filledWithUnstrainedHoney = false;
        SpawnStrainedHoney();
        StopCoroutine(StrainingHoney());
    }

    private void SpawnStrainedHoney()
    {
        strainedHoney = false;
        Instantiate(honeyForSale, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
