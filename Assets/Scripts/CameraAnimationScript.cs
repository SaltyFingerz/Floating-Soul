using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{
    private Animator anim;

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

   
    void Update()
    {
       

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
