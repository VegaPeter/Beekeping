using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipPPE : MonoBehaviour
{
    [SerializeField] PPEEquipManager _ppeObjectToRef;
    // Start is called before the first frame update
    void Start()
    {
        _ppeObjectToRef = FindObjectOfType<PPEEquipManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _ppeObjectToRef.CompareEquippedPPEToCorrectPPE(this.gameObject);
            Debug.Log("Called");
        }
    }
}
