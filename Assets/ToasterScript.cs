using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterScript : MonoBehaviour
{
    public ParticleSystem Smoke;
    public AudioSource ToasterOnSound;
    public Animator BreadAnim;
    public AmanitaVoiceManager AmanitaVoice;
    
public void TurnOnToaster()
    {
        if (AmanitaVoiceManager.toasterWorking)
        {
            AmanitaVoiceManager.isToasting = true;
            ToasterOnSound.Play();
            StartCoroutine(SmokeProgression());
            BreadAnim.SetTrigger("In");
        }
    }

    IEnumerator SmokeProgression()
    {
        yield return new WaitForSeconds(4);
        AmanitaVoice.WhereIsBoletusPlay();
        yield return new WaitForSeconds(3);
        Smoke.Play();


    }
}
