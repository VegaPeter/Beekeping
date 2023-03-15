using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeekeeperHealthManager : MonoBehaviour
{
    [SerializeField] private int health = 50, maxHealth;
    [SerializeField] private GameObject DeathCanvas;
    public bool equippedPPE;

    private void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage()
    {
        if(equippedPPE)
        {
            health -= 5;
        }
        else
        {
            health -= 209;
        }

        //Flash red borders aroudn edge of screen

        Debug.Log("Current Health: " + health);
    }

    public void Die()
    {
        DeathCanvas.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
