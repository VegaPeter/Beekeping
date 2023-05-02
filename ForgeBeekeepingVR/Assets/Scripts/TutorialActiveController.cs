using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialActiveController : MonoBehaviour
{
    [SerializeField] List<GameObject> tutorialList = new List<GameObject>();
    private int index = 0;

    public void SetNextTutorialActive()
    {
        if (index > tutorialList.Count) return;

        index++;
        tutorialList[index].gameObject.SetActive(true);
    }
}
