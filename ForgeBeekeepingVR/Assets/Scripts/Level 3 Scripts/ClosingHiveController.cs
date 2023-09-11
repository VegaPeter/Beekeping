using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingHiveController : MonoBehaviour
{
    [SerializeField] GameObject _staticInnerCover;
    [SerializeField] GameObject _staticOuterCover;
    bool _innerCoverPlaced, _outerCoverPlaced, _hiveCovered;

    public bool HiveCovered
    {
        get { return _hiveCovered; }
        set { _hiveCovered = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Inner Cover"))
        {
            _staticInnerCover.SetActive(true);
            other.gameObject.SetActive(false);
            _innerCoverPlaced = true;
        }
        else if(other.CompareTag("Outer Cover"))
        {
            _staticOuterCover.SetActive(true);
            other.gameObject.SetActive(false);
            _outerCoverPlaced = true;
        }

        if(_outerCoverPlaced && _innerCoverPlaced)
        {
            _hiveCovered = true;
        }
    }
}
