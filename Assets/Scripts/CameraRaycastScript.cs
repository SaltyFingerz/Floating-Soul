using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastScript : MonoBehaviour
{
    public GameObject cam;
    RaycastHit whatHit;
    Vector3 collision = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDrawGizmos() //to visualise the raycast, and whether it is detecting an enemy
    {


        Gizmos.color = Color.red;


        Gizmos.DrawWireSphere(collision, radius: 0.5f);
        Gizmos.DrawLine(transform.position, collision);
    }
    // Update is called once per frame
    void Update()
    {
        
        int mask = 1 << LayerMask.NameToLayer("Default"); //sets the mask for the raycasting to not detext the sword which is in front of the camera, to detect other objects. This was done following the tutorial available at www.youtube.com/watch?v=WpQOBsxFciE&t=312s , specifically at the timestamp: 5:16 - 5:40

        var ray = new Ray(origin: cam.transform.position, direction: cam.transform.forward); //the ray of the raycast is set to originate from cam2, which is the camera that moves with the strike trail, when the main camera is static, meaning cam2 is the camera faces in the direction of the target, not precisely the same as the direction the player is looking at.
        RaycastHit hit;
        Physics.Raycast(ray, out whatHit, maxDistance: 1.5f, mask);

        if (whatHit.collider != null)
        {
          

            if (whatHit.collider.gameObject.CompareTag("lady"))
            {
                print("you're looking at a lady");
            }
            else
            {
                print("not looking at a lady");
            }
        }
        
    }
}
