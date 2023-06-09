using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTar;
    public Transform rigTar;
    public Vector3 trackPosOff;
    public Vector3 trackRotOff;

    public void Map()
    {
        rigTar.position = vrTar.TransformPoint(trackPosOff);
        rigTar.rotation = vrTar.rotation * Quaternion.Euler(trackRotOff);
    }
}

public class VRRig : MonoBehaviour
{
    public float turnSmoothness;
    public VRMap head;
    public VRMap left;
    public VRMap right;

    public Transform mainC;
    Vector3 headBodOff;
   public Transform VrH;

    private void Start()
    {
        headBodOff = transform.position - VrH.position;
    }

    private void LateUpdate()
    {
        transform.position = VrH.position + headBodOff;
        transform.forward = Vector3.Lerp(transform.forward,
            Vector3.ProjectOnPlane(mainC.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.Map();
        left.Map();
        right.Map();
    }
}
