using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPEEquipManager : MonoBehaviour
{
    [SerializeField] GameObject[] _PPEToEquip;
    [SerializeField] Material _baseMat, _incorrectMat, _correctMat;

    int _correctlyEquippedPPECount = -1;

    // Update is called once per frame
    void Update()
    {
        if (_correctlyEquippedPPECount == 4)
        {
            PPEEquippedInCorrectOrder();
            _correctlyEquippedPPECount++;
        }
    }

    public void CompareEquippedPPEToCorrectPPE(GameObject equippedPPE)
    {
        _correctlyEquippedPPECount++;

        _baseMat = equippedPPE.GetComponent<Renderer>().material;

        Debug.Log(equippedPPE.name + " : " + _PPEToEquip[_correctlyEquippedPPECount].name + ". Count is: " + _correctlyEquippedPPECount);

        if (equippedPPE.name == _PPEToEquip[_correctlyEquippedPPECount].name)
        {
            StartCoroutine(ChangeMaterialDelay(equippedPPE, equippedPPE.GetComponent<Renderer>(), .5f, _baseMat, _correctMat, true));
            
        }
        else
        {
            StartCoroutine(ChangeMaterialDelay(equippedPPE, equippedPPE.GetComponent<Renderer>(), .75f, _baseMat, _incorrectMat, false));
            //Equipped PPE is incorrect
        }
    }

    void PPEEquippedInCorrectOrder()
    {
        //Allows the player to progress
        Debug.Log("All PPE Equipped");
    }

    IEnumerator ChangeMaterialDelay(GameObject GO, Renderer correctPPERenderer, float timedelay, Material _base, Material _matToChangeTo, bool shouldDelete)
    { 
        correctPPERenderer.GetComponent<Renderer>().material = _matToChangeTo;

        yield return new WaitForSeconds(timedelay);

        correctPPERenderer.GetComponent<Renderer>().material = _base;

        yield return new WaitForSeconds(timedelay);

        if (shouldDelete)
        {
            Destroy(GO);
        }
    }
}
