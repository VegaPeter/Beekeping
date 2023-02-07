using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingPPE : MonoBehaviour
{
    [SerializeField] GameObject ppeSuit;
    [SerializeField] GameObject helmetMeshScreen;
    [SerializeField] AudioSource zipSound;

    private void Awake()
    {
        //ppeSuit = this.GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ppeSuit.SetActive(false);
            //play zipping sound
            //zipSound.Play();
            //equip gloved hands (scary)
            //lower beekeeping helmet mesh
            //while (helmetMeshScreen.transform.localPosition.y >= 3f)
            //{
            //    helmetMeshScreen.transform.localPosition -= new Vector3(0, .5f, 0);
            //}
        }
    }
}
