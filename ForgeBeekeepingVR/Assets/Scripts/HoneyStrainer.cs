using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyStrainer : MonoBehaviour
{
    private bool filledWithUnstrainedHoney = true,strainedHoney;

    [SerializeField] private GameObject honeyInStrainer;
    [SerializeField] private GameObject honeyForSale;
    [SerializeField] private GameObject strainingTeeth;
    [SerializeField] private Transform targetHoneyPos;
    private BucketController bucketController;
    private bool raiseHoney, strainerON;

    private void FixedUpdate()
    {
        if (raiseHoney)
        {
            honeyInStrainer.transform.position = Vector3.MoveTowards(honeyInStrainer.transform.position, targetHoneyPos.position, 0.03f * Time.deltaTime);

            if (honeyInStrainer.transform.localPosition.y >= targetHoneyPos.localPosition.y)
            {
                raiseHoney = false;
                filledWithUnstrainedHoney = true;
                Debug.Log("No longer raising honey");
            }
        }
        else if (strainerON)
        {
            RotateTeeth();
        }
    }

    public void StartStrainer()
    {
        if (filledWithUnstrainedHoney)
        {
            StartCoroutine(StrainingHoney());
            strainerON = true;
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

            if (honeyInStrainer.transform.localPosition.y <= 2f)
            {
                raiseHoney = true;
            }
            Debug.Log("Filled with honey");
            bucketController.EmptyBucket();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        raiseHoney = false;
    }

    private IEnumerator StrainingHoney()
    {
        yield return new WaitForSeconds(45);

        strainedHoney = true;
        filledWithUnstrainedHoney = false;
        honeyInStrainer.transform.localPosition = new Vector3(0, 0.196f, 0);

        SpawnStrainedHoney();

        strainerON = false;

        StopCoroutine(StrainingHoney());
    }

    public void SpawnStrainedHoney()
    {
        strainedHoney = false;
        Instantiate(honeyForSale, new Vector3(106.872f, 30.763f, 87.819f), Quaternion.identity); //Felt lazy and just manually got its world coordinates. 
    }

    public void Debugger()
    {
        strainerON = true;
    }

    private void RotateTeeth()
    {
        strainingTeeth.transform.Rotate(0, 0f, 1f, Space.Self);
    }
}
