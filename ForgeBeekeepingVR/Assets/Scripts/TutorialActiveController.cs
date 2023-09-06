using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialActiveController : MonoBehaviour
{
    [SerializeField] List<GameObject> tutorialList = new List<GameObject>();
    private int index = 0;

    public void SetNextTutorialActive()
    {
        if (index >= tutorialList.Count - 1) return;

        index++;
        Collider coll = tutorialList[index].gameObject.GetComponent<BoxCollider>();
        coll.enabled = false;
        tutorialList[index].gameObject.SetActive(true);

        StartCoroutine(EnableCollider(coll));
    }

    IEnumerator EnableCollider(Collider colliderToEnable)
    {
        yield return new WaitForSeconds(1.5f);
        colliderToEnable.enabled = true;
    }
}
