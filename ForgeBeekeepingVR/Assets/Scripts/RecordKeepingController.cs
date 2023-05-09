using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordKeepingController : MonoBehaviour
{
    [SerializeField] GameObject _whyIsRecordKeepingImportantUI;
    [SerializeField] Vector3 minScale, maxScale;
    [SerializeField] float rateOfLerp = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WritingInstrument"))
        {
            _whyIsRecordKeepingImportantUI.SetActive(true);
            _whyIsRecordKeepingImportantUI.transform.localScale = Vector3.Lerp(_whyIsRecordKeepingImportantUI.transform.localScale, maxScale, rateOfLerp * Time.deltaTime);
        }
    }

    private void Start()
    {
        _whyIsRecordKeepingImportantUI.SetActive(true);
        _whyIsRecordKeepingImportantUI.transform.localScale = Vector3.Lerp(_whyIsRecordKeepingImportantUI.transform.localScale, maxScale, rateOfLerp * Time.deltaTime);
    }
}
