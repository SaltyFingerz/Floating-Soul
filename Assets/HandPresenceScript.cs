using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresenceScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position of hand controller
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //rotation of hand controller
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotationDiffernceInDegree = angleInDegree* rotationAxis;
        rb.angularVelocity = (rotationDiffernceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
