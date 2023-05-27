using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmanitaVoiceManager : MonoBehaviour
{
    public AudioSource AmanitaVoice;
    public AudioClip ILoveMyLife;
    public AudioClip RingSpeech;
    public GameObject EngagementRing;
    public CameraRaycastScript CameraRaycast;
    public SmokeDetectorScript SmokeDetector;
    public AudioClip[] TimeToPutKettle;
    public AudioClip[] WhilePuttingKettle;
    public AudioClip[] ToastOn;
    public AudioClip KettleOnTeaToastAndRing;
    public AudioClip WhereIsBoletus;
    public AudioClip KettleSounds;
    public AudioClip WhatIfShesNot;
    public AudioClip IShouldTakeKettleOff;
    public AudioClip MarriageCommitment;
    public AudioClip KettleDefinitelyBoiling;
    public AudioClip WhereIsShe;
    public AudioClip SmokeOhNo;
    public AudioClip AhWhatAboutBoletus;
    private bool isKettleTime;
    public static bool isOnStove;
    public static bool isTouchingKettle;
    private bool isToastTime;
    public static bool isToasting;
    public CameraAnimationScript camAnim;
    private ActionBasedContinuousMoveProvider aBCP;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpeakingAmanita());
        aBCP = GetComponent<ActionBasedContinuousMoveProvider>();
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
            if (!AmanitaVoice.isPlaying && !KettleScript.boiled)
            {
                StartCoroutine(PromptDelay());
            }
        }

       if(isOnStove &&!isToasting)
        {
            isToastTime = true;
        }

      


        if(isToasting)
        {
            isToastTime = false;
        }

       /* if(isToastTime && !AmanitaVoice.isPlaying)
        {
            PromptToast();
        }
       */

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

    public void PromptToast()
    {
        isToastTime = false;
        toasterWorking = true;
       
      StartCoroutine(ToastPromptRepeat());
    

        if (!isToasting)
        {
            isToastTime = true;
        }

    }

    IEnumerator ToastPromptRepeat()
    {
        yield return new WaitForSeconds(1);
        AudioClip clip = ToastOn[UnityEngine.Random.Range(0, ToastOn.Length)];
        if(!AmanitaVoice.isPlaying && !isToasting)
        AmanitaVoice.PlayOneShot(clip); 
        yield return new WaitForSeconds(8);
        if (!AmanitaVoice.isPlaying && !isToasting)
            AmanitaVoice.PlayOneShot(clip);
        yield return new WaitForSeconds(8);
        if (!AmanitaVoice.isPlaying && !isToasting)
            AmanitaVoice.PlayOneShot(clip);
        yield return new WaitForSeconds(8);
        if (!AmanitaVoice.isPlaying && !isToasting)
            AmanitaVoice.PlayOneShot(clip);
        yield return new WaitForSeconds(8);
        if (!AmanitaVoice.isPlaying && !isToasting)
            AmanitaVoice.PlayOneShot(clip);
        yield return new WaitForSeconds(15);
        if (!AmanitaVoice.isPlaying && !isToasting)
            AmanitaVoice.PlayOneShot(clip);

    }
    public void PuttingKettleOn()
    {
        if (!AmanitaVoice.isPlaying && !isOnStove && !KettleScript.boiled)
        {
            AudioClip clip = WhilePuttingKettle[UnityEngine.Random.Range(0, WhilePuttingKettle.Length)];
            AmanitaVoice.PlayOneShot(clip);
        }

    }


    IEnumerator StartSpeakingAmanita()
    {
        yield return new WaitForSeconds(3);
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


    public void WhereIsBoletusPlay()
    {
        if (!AmanitaVoice.isPlaying)
        {
            StartCoroutine(WorriedThoughtsOverlay());
        }
        
    }

    public static bool toasterWorking = false;
    private bool smoking = false;
    IEnumerator WorriedThoughtsOverlay()
    {

        toasterWorking = false;

            AmanitaVoice.PlayOneShot(WhereIsBoletus);
        
        yield return new WaitForSeconds(10);


               AmanitaVoice.PlayOneShot(KettleSounds);
        yield return new WaitForSeconds(3);


        AmanitaVoice.PlayOneShot(WhatIfShesNot);
           yield return new WaitForSeconds(3);
        //AmanitaVoice.PlayOneShot(IShouldTakeKettleOff);
        //yield return new WaitForSeconds(2);
        AmanitaVoice.PlayOneShot(MarriageCommitment);
        yield return new WaitForSeconds(4);
        AmanitaVoice.PlayOneShot(KettleDefinitelyBoiling);
        yield return new WaitForSeconds(3);
        AmanitaVoice.PlayOneShot(WhereIsShe);
       // yield return new WaitForSeconds(2);
        smoking = true;

       

    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("zone") && smoking &&!finalAminta)
        {
            StartCoroutine(OhNoSmokePlay());
            aBCP.moveSpeed = 0;

        }
    }
    bool finalAminta = false;
    public IEnumerator OhNoSmokePlay()
    {
        if (!AmanitaVoice.isPlaying)
        {

            finalAminta = true;
            AmanitaVoice.PlayOneShot(SmokeOhNo);
            yield return new WaitForSeconds(5);
            SmokeDetector.PlayAlarm();
            AmanitaVoice.PlayOneShot(AhWhatAboutBoletus);
            yield return new WaitForSeconds(9);
            camAnim.DanDanDan();
        }
    }
    public void TimeToPutTheKettleOn()
    {
        AudioClip clip = TimeToPutKettle[UnityEngine.Random.Range(0, TimeToPutKettle.Length)];
        AmanitaVoice.PlayOneShot(clip);
    }

   
}
