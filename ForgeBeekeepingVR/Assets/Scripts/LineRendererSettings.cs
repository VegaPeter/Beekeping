using HurricaneVR.Framework.ControllerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HurricaneVR.Framework.ControllerInput;


public class LineRendererSettings : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] LineRenderer rend;
    [SerializeField] HVRPlayerInputs playerRig;
    Vector3[] points;
    Button btn;

    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, -20);

        rend.SetPositions(points);
        rend.enabled = true;
    }

    void Update()
    {
        AlignLineRenderer(rend);

        if(AlignLineRenderer(rend) && playerRig.IsRightTriggerHoldActive == true)
        {
            btn.onClick.Invoke();
        }
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn;

        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, -hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, -20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            hitBtn = false;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;

        return hitBtn;
    }
}
