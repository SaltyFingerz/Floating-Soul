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

    public void AmanitaCallingByB()
    {
       StartCoroutine(CallingRoutine());
    }

    IEnumerator CallingRoutine()
    {
        if (!BoletusVoice.isPlaying)
        {
            BoletusVoice.PlayOneShot(AmanitaImHome);
            yield return new WaitForSeconds(3);
            BoletusVoice.PlayOneShot(AmanitaQuestioningly);
            yield return new WaitForSeconds(2);
            BoletusVoice.PlayOneShot(AmanitaConcerned);
            yield return new WaitForSeconds(1);
            StartCoroutine(ShockedRoutine());
        }

    }

    public void ShockedCallingRoutine()
    {
        StartCoroutine(ShockedRoutine());
    }

    IEnumerator ShockedRoutine()
    {
        BoletusVoice.PlayOneShot(AmanitaShocked1);
        yield return new WaitForSeconds(2);
        BoletusVoice.PlayOneShot(AmanitaShocked2);
        yield return new WaitForSeconds(3);
        BoletusVoice.PlayOneShot(AmanitaShocked3);
        yield return new WaitForSeconds(1);
        AmanitaSadRealising();
    }

    public void AmanitaSadRealising()
    {
        BoletusVoice.PlayOneShot(AmanitaRealising);
        StartCoroutine(StartCry());
    }

    IEnumerator StartCry()
    {
        yield return new WaitForSeconds(1);
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
    {if (!AnimationEventSu.MindOpen)
        {
            BoletusVoice.PlayOneShot(CryingLong);
        }

    else if(AnimationEventSu.MindOpen)
        {
            StartCoroutine(IKnowYoureThereRoutine());
        }
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

   

    public void IKnowYoureListening()
    {
        BoletusVoice.PlayOneShot(NoAmanitaWakeUpIknowYoureListening);
    }

    public void ThatsOddIFeelHer()
    {
        BoletusVoice.PlayOneShot(ThatsOdd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

