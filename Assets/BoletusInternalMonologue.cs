using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoletusInternalMonologue : MonoBehaviour
{
    public BoletusBodyVoiceScript BoletusVoicOuter;
    public AudioSource BoletusVoice;
    public AudioSource BoletusAfterCrying;
    public AudioClip ThatsOdd;
    public AudioClip AAAA;
    public AudioClip WhytoDied;
    public AudioClip MyNegtoButter;
    public AudioClip CryMedium;
    public AudioClip CryTwo;
    public AudioClip WhatAmIGoingToDo;
    public AudioClip SheWasAlwaysThere;
    public AudioClip WhatsThatInHerPocket;
    public AudioClip ABox;
    public AudioClip SheWasGoingToPropose;
    public AudioClip YES;
    public AudioClip WhatsThatSmell;
    public AudioClip IShouldTurnTheStoveOff;
    public AudioClip IdontWantToDoAnything;
    public AudioClip PhoneRings;
    public AudioClip Greeting;
    public AudioClip MessageBySu;
    public GameObject GhostHandLeft;
    public GameObject GhostHandRight;
    
    public GameObject CellPhone;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftHandPose;
    public GameObject RightHandPose;
    public GameObject RingBox;
    public GameObject RingOnFinger;
    public GameObject CallingScreen;
    public GameObject LeftHandAlive;
    public GameObject RightHandAlive;
    public GameObject BoxInHand;
    public GameObject LeftHandVsibilityBol;
    public GameObject RightHandVsibilityBol;
    bool monologuing = false;
    public static bool End;
    bool stopCrying = false;
    IEnumerator BoletusMonologue()
    {
        stopCrying = true;
       

        BoletusAfterCrying.PlayOneShot(AAAA);

        GhostHandLeft.SetActive(false);
        GhostHandRight.SetActive(false);

        LeftHandVsibilityBol.SetActive(false);
        RightHandVsibilityBol.SetActive(false);
        RightHandAlive.SetActive(true);
        LeftHandAlive.SetActive(true);

        yield return new WaitForSeconds(2);
        BoletusAfterCrying.PlayOneShot(WhytoDied); yield return new WaitForSeconds(14);
        BoletusAfterCrying.PlayOneShot(CryMedium); yield return new WaitForSeconds(8);
        BoletusAfterCrying.PlayOneShot(MyNegtoButter); yield return new WaitForSeconds(13);
   
        BoletusAfterCrying.PlayOneShot(CryMedium); yield return new WaitForSeconds(8);
        BoletusAfterCrying.PlayOneShot(WhatAmIGoingToDo); yield return new WaitForSeconds(14);
      //  BoletusAfterCrying.PlayOneShot(SheWasAlwaysThere); yield return new WaitForSeconds(51);
   
        BoletusAfterCrying.PlayOneShot(WhatsThatInHerPocket); yield return new WaitForSeconds(4);
        BoletusAfterCrying.PlayOneShot(ABox); yield return new WaitForSeconds(1);
        RingBox.SetActive(false);
        BoxInHand.SetActive(true);
        BoletusAfterCrying.PlayOneShot(SheWasGoingToPropose); yield return new WaitForSeconds(3);
       
        BoletusAfterCrying.PlayOneShot(YES);
        BoxInHand.SetActive(false);

        RingOnFinger.SetActive(true);
    
            yield return new WaitForSeconds(12);
         
        BoletusAfterCrying.PlayOneShot(WhatsThatSmell); yield return new WaitForSeconds(3);
        BoletusAfterCrying.PlayOneShot(IShouldTurnTheStoveOff); yield return new WaitForSeconds(3);
        BoletusAfterCrying.PlayOneShot(IdontWantToDoAnything); yield return new WaitForSeconds(3);
            CellPhone.SetActive(true);
            CellPhone.GetComponent<AudioSource>().PlayOneShot(PhoneRings); yield return new WaitForSeconds(6);
            CellPhone.GetComponent<AudioSource>().PlayOneShot(Greeting); yield return new WaitForSeconds(7);
            CellPhone.GetComponent<AudioSource>().PlayOneShot(MessageBySu);
            CallingScreen.SetActive(false);
            yield return new WaitForSeconds(4);
            End = true;
        

    }

    public void StartBoletusMonologue()
    {
        transform.rotation = new Quaternion(0, 180, 0,0);
        BoletusVoicOuter.StopTalking();
        if (!BoletusVoice.isPlaying)
        {
            StartCoroutine(Crying());
            monologuing = true;
            GhostHandLeft.SetActive(true);
            GhostHandRight.SetActive(true);
        }
      
    }

    IEnumerator Crying()
    {

        BoletusVoice.PlayOneShot(ThatsOdd);
        yield return new WaitForSeconds(7);
        BoletusVoice.PlayOneShot(CryMedium);
        yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(CryTwo);
        yield return new WaitForSeconds(15);
        BoletusVoice.PlayOneShot(CryMedium);
        yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(CryTwo);
        yield return new WaitForSeconds(15);
        BoletusVoice.PlayOneShot(CryMedium);
        yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(CryTwo);
        yield return new WaitForSeconds(15);
        BoletusVoice.PlayOneShot(CryMedium);
        yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(CryMedium);
        yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(CryTwo);
        yield return new WaitForSeconds(15);
       
    }

   
    public void AAMonologue()
    {
        if (monologuing)
        {
            StopCoroutine(Crying());
            BoletusVoice.Stop();
            StartCoroutine(BoletusMonologue());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stopCrying)
        {
            BoletusVoice.Stop();

        }
    }


}
