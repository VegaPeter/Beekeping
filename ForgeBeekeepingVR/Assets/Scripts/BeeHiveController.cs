using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHiveController : MonoBehaviour
{
    [SerializeField] ParticleSystem beeParticles;
    [SerializeField] AudioSource beeAudio;
    [SerializeField] GameObject hiveFrame1, hiveFrame2, hiveFrame3, innerCover;

    private int beeAngerLevel;
    private float startVolume;

    [SerializeField] private BeekeeperHealthManager healthManager;

    //Attacking
    public float timeBetweenAttacks = 3f;
    bool alreadyAttacked;

    void Start()
    {
        startVolume = beeAudio.volume;

        hiveFrame1.SetActive(false);
        hiveFrame2.SetActive(false);
        hiveFrame3.SetActive(false);
        innerCover.SetActive(true);
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
                while (beeAudio.volume >= 0.05f) { beeAudio.volume -= startVolume * Time.deltaTime; }
                StartCoroutine(BeesRecovering());
                beeAngerLevel = 0;
                break;
            case 1:
                //Bees are at the default level and currently aren't swarming
                emission.rateOverTime = 55;
                velocity.speedModifier = 1;
                while (beeAudio.volume <= startVolume) { beeAudio.volume += startVolume * Time.deltaTime; }
                StopCoroutine(BeesRecovering());
                beeAngerLevel = 1;
                break;
            case 2:
                //Bees are angry that the hive is being interferred with
                emission.rateOverTime = 75;
                velocity.speedModifier = 1.2f;
                while (beeAudio.volume <= 0.26f) { beeAudio.volume += startVolume * Time.deltaTime; }
                beeAngerLevel = 2;
                break;
            case 3:
                //Bees are swarming to protect their queen
                emission.rateOverTime = 100;
                velocity.speedModifier = 1.5f;
                while (beeAudio.volume <= 0.5f) { beeAudio.volume += startVolume * Time.deltaTime; }
                beeAngerLevel = 3;
                break;
            default:
                break;
        }
    }

    private IEnumerator BeesRecovering()
    {
        yield return new WaitForSeconds(20);
        BeeAgressionManager(1);
    }
    
    private IEnumerator CoverRemoved()
    {
        yield return new WaitForSeconds(1.5f);

        hiveFrame1.SetActive(true);
        hiveFrame2.SetActive(true);
        hiveFrame3.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        hiveFrame1.GetComponentInChildren<MeshRenderer>().enabled = true;
        hiveFrame2.GetComponentInChildren<MeshRenderer>().enabled = true;
        hiveFrame3.GetComponentInChildren<MeshRenderer>().enabled = true;

        innerCover.SetActive(false);

        yield return new WaitForSeconds(1);

        BeeAgressionManager(2);
    }

    public void HiveCoverRemoved()
    {
        StartCoroutine(CoverRemoved());
        StopCoroutine(CoverRemoved());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked && beeAngerLevel >= 2)
        {
            healthManager.TakeDamage();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
