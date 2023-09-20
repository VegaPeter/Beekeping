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
            _whyIsRecordKeepingImportantUI.GetComponent<RectTransform>().transform.localScale = maxScale;
            _whyIsRecordKeepingImportantUI.SetActive(true);
            _whyIsRecordKeepingImportantUI.transform.localScale = Vector3.Lerp(_whyIsRecordKeepingImportantUI.transform.localScale, maxScale, rateOfLerp * Time.deltaTime);
        }
    }

    private void Start()
    {
        //_whyIsRecordKeepingImportantUI.GetComponent<RectTransform>().transform.localScale = maxScale;

        _whyIsRecordKeepingImportantUI.SetActive(true);
        //_whyIsRecordKeepingImportantUI.transform.localScale = Vector3.Lerp(_whyIsRecordKeepingImportantUI.transform.localScale, maxScale, rateOfLerp * Time.deltaTime);
        _whyIsRecordKeepingImportantUI.GetComponent<RectTransform>().transform.localScale = Vector3.Lerp(_whyIsRecordKeepingImportantUI.transform.localScale, maxScale, rateOfLerp * Time.deltaTime);
    }
}
