using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{
    private Animator anim;
    public Animator EyeLidAnim;
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
        EyeLidAnim.SetTrigger("Pain");
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
        
       
        

    }

    IEnumerator MomentOfDeath()
    {
        fastestHeartAttack.Stop();
        DeathScript.Dead = true;
        yield return null;
    }
}
