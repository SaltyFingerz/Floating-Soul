using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoletusBodyVoiceScript : MonoBehaviour
{
    private AudioSource BoletusVoice;

    public AudioClip AmanitaImHome;
    public AudioClip AmanitaQuestioningly;
    public AudioClip AmanitaConcerned;
    public AudioClip AmanitaShocked1;
    public AudioClip AmanitaShocked2;
    public AudioClip AmanitaShocked3;
    public AudioClip AmanitaRealising;
    public AudioClip CryingLong;
    public AudioClip CryingMedium;
    public AudioClip NoAmanitaStartCry;
    public AudioClip NoAmanitaWakeUpIknowYoureListening;
    public AudioClip ThatsOdd;
    // Start is called before the first frame update
    void Start()
    {
       BoletusVoice = GetComponent<AudioSource>(); 
    }

    //public void AmanitaCallingByB()
    //{
    //    BoletusVoice.PlayOneShot(AmanitaImHome);
    //    AmanitaSadRealising();

    //}

    public void CallingRoute()
    {
        BoletusVoice.PlayOneShot(AmanitaConcerned);

    }
  

    //public void ShockedCallingRoutine()
    //{
    //    StartCoroutine(ShockedRoutine());
    //}

    //IEnumerator ShockedRoutine()
    //{
    //    BoletusVoice.PlayOneShot(AmanitaShocked3);
    //    yield return new WaitForSeconds(2);
    //    AmanitaSadRealising();
    //}

    public void AmanitaSadRealising()
    {
   
        StartCoroutine(StartCry());
    }

    IEnumerator StartCry()
    {
        yield return new WaitForSeconds(4);
        BoletusVoice.PlayOneShot(NoAmanitaStartCry);
        yield return new WaitForSeconds(5);
        CryLong();
    }
 
    public void CryLoop1()
    {
        if(!BoletusVoice.isPlaying && keepCrying)
        {
            CryLong();
        
             
        }
    }

    bool keepCrying = true;
    public void CryLoop2() 
    {
        if(!BoletusVoice.isPlaying && keepCrying)
        {
            CryMedium();
        }
    }
    public void CryLong()
    {
   
            BoletusVoice.PlayOneShot(CryingLong);
    }

   
  

    IEnumerator IKnowYoureThereRoutine()
    {
        BoletusVoice.Stop();
        yield return new WaitForEndOfFrame();
        IKnowYoureListening();
    }
    public void CryMedium()
    {
        BoletusVoice.PlayOneShot(CryingMedium);
    }

   public void StopTalking()
    {
        BoletusVoice.Stop();
    }

    public void IKnowYoureListening()
    {
        BoletusVoice.PlayOneShot(NoAmanitaWakeUpIknowYoureListening);
    }

    public void ThatsOddIFeelHer()
    {
        if(gameObject.activeSelf)
        BoletusVoice.PlayOneShot(ThatsOdd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

