using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchButtonInterface : MonoBehaviour
{
    [SerializeField] SmokerController SC;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RightHandIndex"))
        {
            Button btn;
            btn = this.gameObject.GetComponent<Button>();
            btn.onClick.Invoke();

            //Changing the button's display
            if(SC.IsLit) {btn.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Smother Smoker";}
            else {btn.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Light Smoker";}
        }
    }
}
