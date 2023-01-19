using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveController : MonoBehaviour
{
    [SerializeField] ParticleSystem beeParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Evil human detected");
            var emission = beeParticles.emission;
            emission.rateOverTime = 100;
        }
    }

    //private IEnumerator BeeRaging()
    //{

    //    yield return new WaitForSeconds();
    //}
}
