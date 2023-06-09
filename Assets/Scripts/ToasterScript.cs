using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterScript : MonoBehaviour
{
    public ParticleSystem Smoke;
    public AudioSource ToasterOnSound;
    public Animator BreadAnim;
    public AmanitaVoiceManager AmanitaVoice;
    private SphereCollider ToastTrigger;
    public GameObject bread;
    public GameObject toast;

    private void Start()
    {
        ToastTrigger = GetComponent<SphereCollider>();
    }
    public void TurnOnToaster()
    {
        if (AmanitaVoiceManager.toasterWorking)
        {
            AmanitaVoiceManager.isToasting = true;
            ToasterOnSound.Play();
            StartCoroutine(SmokeProgression());
            BreadAnim.SetTrigger("In");
            ToastTrigger.enabled = false;
        }
    }

    IEnumerator SmokeProgression()
    {
        yield return new WaitForSeconds(4);
        AmanitaVoice.WhereIsBoletusPlay();
        yield return new WaitForSeconds(15);
        bread.SetActive(false);
        toast.SetActive(true);
        Smoke.Play();


    }
}
