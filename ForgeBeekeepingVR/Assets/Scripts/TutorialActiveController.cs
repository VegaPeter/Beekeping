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
        tutorialList[index].gameObject.SetActive(true);
    }
}
