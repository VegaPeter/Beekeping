using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerForPhysics : MonoBehaviour
{
    [SerializeField] GameObject targ;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, .1f);
    }
}
