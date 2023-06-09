using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastScript : MonoBehaviour
{
    public static bool LookingSu;
    public static bool lookingAtRing;
    void Update()
    {
        RaycastSingle();
        
    }
    private void RaycastSingle()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        Debug.DrawRay(origin, direction * 100f, Color.red);
        Ray ray = new Ray(origin, direction);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            // raycastHit.collider.GetComponent<Renderer>().material.color = tintColor;
            if (raycastHit.collider.gameObject.CompareTag("lady"))
            {
                LookingSu = true;
            }
            else
            {
                LookingSu = false;
            }

            if(raycastHit.collider.gameObject.CompareTag("ring"))
            {
                lookingAtRing = true;
            }
            else
            {
                lookingAtRing= false;
            }
        }
    }
}
