using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingPPE : MonoBehaviour
{
    [SerializeField] GameObject ppeSuit;
    [SerializeField] GameObject helmetMeshScreen;
    [SerializeField] AudioSource zipSound;

    [SerializeField] private BeekeeperHealthManager healthManager;
    //BeeKeeper UI
    public int downPos, upPos;

    //New PPE Script
    [SerializeField]
    GameObject[] _PPEToEquip;


    private void Start()
    {
        //helmetMeshScreen.transform.position = new Vector3(0,upPos, 0);
    }

    private void FixedUpdate()
    {
        //if(shouldLowerMesh)
        //{
        //    helmetMeshScreen.transform.position = Vector3.MoveTowards(helmetMeshScreen.transform.position, new Vector3(0, downPos, 0), 0.3f * Time.deltaTime);

        //    if(helmetMeshScreen.transform.position == new Vector3(0, downPos, 0))
        //    {
        //        shouldLowerMesh = false;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ppeSuit.SetActive(false);

            //play zipping sound
            zipSound.Play();

            //equip gloved hands (scary)
            healthManager.equippedPPE = true;
        }
    }
}
