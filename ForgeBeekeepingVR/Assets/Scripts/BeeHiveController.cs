using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveController : MonoBehaviour
{
    [SerializeField] ParticleSystem beeParticles;
    [SerializeField] AudioSource beeAudio;

    private float startVolume;

    // Start is called before the first frame update
    void Start()
    {
        startVolume = beeAudio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeeAgressionManager(int currentAgroLevel)
    {
        var emission = beeParticles.emission;
        var velocity = beeParticles.velocityOverLifetime;
        switch (currentAgroLevel)
        {
            case 0:
                //Bees are smoked and at the lowest aggression
                emission.rateOverTime = 15;
                velocity.speedModifier = 0.5f;
                while (beeAudio.volume >= 0.036f) { beeAudio.volume -= startVolume * Time.deltaTime; }
                StartCoroutine(BeesRecovering());
                break;
            case 1:
                //Bees are at the default level and currently aren't swarming
                emission.rateOverTime = 55;
                velocity.speedModifier = 1;
                while (beeAudio.volume <= startVolume) { beeAudio.volume += startVolume * Time.deltaTime; }
                StopCoroutine(BeesRecovering());
                break;
            case 2:
                //Bees are angry that the hive is being interferred with
                emission.rateOverTime = 75;
                velocity.speedModifier = 1.2f;
                while (beeAudio.volume <= 0.26f) { beeAudio.volume += startVolume * Time.deltaTime; }
                break;
            case 3:
                //Bees are swarming to protect their queen
                emission.rateOverTime = 100;
                velocity.speedModifier = 1.5f;
                while (beeAudio.volume <= 0.5f) { beeAudio.volume += startVolume * Time.deltaTime; }
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Evil human detected");  
        }
    }

    private IEnumerator BeesRecovering()
    {
        yield return new WaitForSeconds(20);
        BeeAgressionManager(1);
    }
}
