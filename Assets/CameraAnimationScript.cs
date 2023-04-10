using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{
    private Animator anim;
    RaycastHit whatHit;
    Vector3 collision = Vector3.zero;
    [SerializeField] private AudioSource heartAttack;

    [SerializeField] private AudioSource normalHeartbeat;

    [SerializeField] private AudioSource faster1Heartbeat;

    [SerializeField] private AudioSource faster2Heartbeat;
    [SerializeField] private AudioSource faster3Heartbeat;

    [SerializeField] private AudioSource fastestHeartAttack;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    private void OnDrawGizmos() //to visualise the raycast, and whether it is detecting an enemy
    {

       
            Gizmos.color = Color.red;
      

        Gizmos.DrawWireSphere(collision, radius: 0.5f);
        Gizmos.DrawLine(transform.position, collision);
    }
    void Update()
    {
        int mask = 1 << LayerMask.NameToLayer("Default"); //sets the mask for the raycasting to not detext the sword which is in front of the camera, to detect other objects. This was done following the tutorial available at www.youtube.com/watch?v=WpQOBsxFciE&t=312s , specifically at the timestamp: 5:16 - 5:40

        var ray = new Ray(origin: transform.position, direction: transform.forward); //the ray of the raycast is set to originate from cam2, which is the camera that moves with the strike trail, when the main camera is static, meaning cam2 is the camera faces in the direction of the target, not precisely the same as the direction the player is looking at.
        RaycastHit hit;
        Physics.Raycast(ray, out whatHit, maxDistance: 1.5f, mask);

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DyingRoutine5678());
          
           
        }
    }

    IEnumerator DyingRoutine5678()
    {
        anim.SetTrigger("pain");
        heartAttack.Play();
        normalHeartbeat.Stop();
        faster1Heartbeat.Play();
        yield return new WaitForSeconds(5f);
        faster1Heartbeat.Stop();
        faster2Heartbeat.Play();
       
        yield return new WaitForSeconds(4f);
        faster2Heartbeat.Stop();
        faster3Heartbeat.Play();
        yield return new WaitForSeconds(4f);
        faster3Heartbeat.Stop();
        fastestHeartAttack.Play();
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("dead");
        yield return new WaitForSeconds(2f);
        fastestHeartAttack.Stop();
        yield return new WaitForSeconds(5f);
        DeathScript.Dead = true;
        

    }
}
