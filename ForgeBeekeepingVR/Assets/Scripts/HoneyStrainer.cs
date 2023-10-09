using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyStrainer : MonoBehaviour
{

    [SerializeField] private GameObject honeyInStrainer;
    [SerializeField] private GameObject honeyForSale;
    [SerializeField] private GameObject strainingTeeth;
    [SerializeField] private GameObject framesInStrainer, frameONEInStrainer, frameTWOInStrainer, frameTHREEInStrainer;

    [SerializeField] private Transform targetHoneyPos;

    private bool filledWithUnstrainedHoney;
    private bool strainerON;

    public int totalFramesInStrainer = 0;

    private void FixedUpdate()
    {
        if (strainerON)
        {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NoFrameNoStrain") || other.CompareTag("Frame"))
        {
            totalFramesInStrainer++;

            switch (totalFramesInStrainer)
            {
                case 1:
                    Destroy(other.gameObject);
                    frameONEInStrainer.SetActive(true);
                    break;

                case 2:
                    Destroy(other.gameObject);
                    frameTWOInStrainer.SetActive(true);
                    break;

                case 3:
                    Destroy(other.gameObject);
                    frameTHREEInStrainer.SetActive(true);
                    break;

                default:
                    break;
            }

            filledWithUnstrainedHoney = true;
            other.gameObject.SetActive(false);
            //Renderer meshRendererFrame = other.gameObject.GetComponentInChildren<MeshRenderer>();
            //meshRendererFrame.gameObject.GetComponentInChildren<GameObject>().SetActive(false);
            //meshRendererFrame.enabled = false;   
        }
    }

    private IEnumerator StrainingHoney()
    {
        yield return new WaitForSeconds(20);

        filledWithUnstrainedHoney = false;

        frameONEInStrainer.SetActive(false);
        frameTWOInStrainer.SetActive(false);
        frameTHREEInStrainer.SetActive(false);

        strainerON = false;

        honeyInStrainer.transform.localPosition = new Vector3(0, 0.196f, 0);
        SpawnStrainedHoney();

        StopCoroutine(StrainingHoney());
    }

    public void SpawnStrainedHoney()
    {
        Instantiate(honeyForSale, new Vector3(112.2966f, 30.828f, 87.784f), Quaternion.identity); //Felt lazy and just manually got its world coordinates. //Fuck you past me. 
    }

    private void RotateTeeth()
    {
        strainingTeeth.transform.Rotate(0, 0f, 1f, Space.Self);
    }
}
