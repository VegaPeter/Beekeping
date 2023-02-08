using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyStrainer : MonoBehaviour
{
    private bool filledWithUnstrainedHoney,strainedHoney;

    [SerializeField] private GameObject honeyInStrainer;
    [SerializeField] private GameObject honeyForSale;
    [SerializeField] private GameObject strainingTeeth;
    [SerializeField] private GameObject framesInStrainer;
    [SerializeField] private Transform targetHoneyPos;
    private bool raiseHoney, strainerON;

    private void FixedUpdate()
    {
        if (strainerON)
        {
            //framesInStrainer.SetActive(true); //will be added to ontriggerenter
            RotateTeeth();
            honeyInStrainer.transform.position = Vector3.MoveTowards(honeyInStrainer.transform.position, targetHoneyPos.position, 0.03f * Time.deltaTime);
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
        if(other.CompareTag("Frame"))
        {
            framesInStrainer.SetActive(true);
            filledWithUnstrainedHoney = true;
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator StrainingHoney()
    {
        yield return new WaitForSeconds(20);

        filledWithUnstrainedHoney = false;
        framesInStrainer.SetActive(false);
        strainerON = false;

        honeyInStrainer.transform.localPosition = new Vector3(0, 0.196f, 0);
        SpawnStrainedHoney();

        StopCoroutine(StrainingHoney());
    }

    public void SpawnStrainedHoney()
    {
        Instantiate(honeyForSale, new Vector3(106.872f, 30.763f, 87.819f), Quaternion.identity); //Felt lazy and just manually got its world coordinates. 
    }


    private void RotateTeeth()
    {
        strainingTeeth.transform.Rotate(0, 0f, 1f, Space.Self);
    }
    public void Debugger()
    {
        strainerON = true;
    }
}
