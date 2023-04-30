using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmanitaVoiceManager : MonoBehaviour
{
    public AudioSource AmanitaVoice;
    public AudioClip ILoveMyLife;
    public AudioClip RingSpeech;
    public GameObject EngagementRing;
    public CameraRaycastScript CameraRaycast;
    public AudioClip[] TimeToPutKettle;
    public AudioClip[] WhilePuttingKettle;
    public AudioClip[] ToastOn;
    public AudioClip KettleOnTeaToastAndRing;
    private bool isKettleTime;
    public static bool isOnStove;
    public static bool isTouchingKettle;
    private bool isToastTime;
    bool isToasting;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpeakingAmanita());
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraRaycastScript.lookingAtRing)
        {
            if (!AmanitaVoice.isPlaying)
            {
                StartCoroutine(StartRingSpeech());
            }
        }

        if (isKettleTime && !isOnStove)
        {
            if (!AmanitaVoice.isPlaying)
            {
                StartCoroutine(PromptDelay());
            }
        }

        if(isToastTime && !AmanitaVoice.isPlaying)
        {
            StartCoroutine(PromptToast());
        }

    }

    IEnumerator PromptDelay()
    {
        isKettleTime = false;
        yield return new WaitForSeconds(4);
        if (!isOnStove)
        {
            if (!isTouchingKettle)
            {
                TimeToPutTheKettleOn();
            }
            isKettleTime = true;
        }
    }

    IEnumerator PromptToast()
    {
        
        yield return new WaitForSeconds(4);
        if(isToastTime)
        {
            AudioClip clip = ToastOn[UnityEngine.Random.Range(0, ToastOn.Length)];
            AmanitaVoice.PlayOneShot(clip);
        }

    }
    public void PuttingKettleOn()
    {
        if (!AmanitaVoice.isPlaying && !isOnStove)
        {
            AudioClip clip = WhilePuttingKettle[UnityEngine.Random.Range(0, WhilePuttingKettle.Length)];
            AmanitaVoice.PlayOneShot(clip);
        }

    }


    IEnumerator StartSpeakingAmanita()
    {
        yield return new WaitForSeconds(4);
        AmanitaVoice.PlayOneShot(ILoveMyLife);
        yield return new WaitForSeconds(22);
        EngagementRing.SetActive(true);
    }

    IEnumerator StartRingSpeech()
    {
        EngagementRing.GetComponent<SphereCollider>().enabled = false;
        CameraRaycastScript.lookingAtRing = false;
        yield return new WaitForSeconds(1);
        AmanitaVoice.PlayOneShot(RingSpeech);
        yield return new WaitForSeconds(10);
        EngagementRing.SetActive(false);
        AmanitaVoice.PlayOneShot(KettleOnTeaToastAndRing);
        yield return new WaitForSeconds(10);
        isKettleTime = true;
       
    }



    public void TimeToPutTheKettleOn()
    {
        AudioClip clip = TimeToPutKettle[UnityEngine.Random.Range(0, TimeToPutKettle.Length)];
        AmanitaVoice.PlayOneShot(clip);
    }

   
}
