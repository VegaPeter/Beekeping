using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyStrainer : MonoBehaviour
{
    private bool filledWithUnstrainedHoney = true,strainedHoney;

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

            while(honeyInStrainer.transform.position.y <= 2f)
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

    public void SpawnStrainedHoney()
    {
        strainedHoney = false; 
        Instantiate(honeyForSale, new Vector3(106.872f, 30.763f, 87.819f), Quaternion.identity); //Felt lazy and just manually got its world coordinates. 
    }

    public void Debugger()
    {
        Debug.Log("why does the button press itself?");
    }
}
