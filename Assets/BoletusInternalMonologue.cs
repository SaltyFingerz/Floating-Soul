using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoletusInternalMonologue : MonoBehaviour
{
    public AudioSource BoletusVoice;
    public AudioClip ThatsOdd;
    public AudioClip AAAA;
    public AudioClip WhywhywhyPunch;
    public AudioClip CryMedium;
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

    
    public GameObject CellPhone;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject LeftHandPose;
    public GameObject RightHandPose;
    public GameObject RingBox;
    public GameObject RingOnFinger;
    public GameObject CallingScreen;

    public static bool End;
    IEnumerator BoletusMonologue()
    {
        BoletusVoice.PlayOneShot(ThatsOdd);
        yield return new WaitForSeconds(7);
        BoletusVoice.PlayOneShot(AAAA);
        LeftHand.SetActive(false);
        RightHand.SetActive(false);
        yield return new WaitForSeconds(2);
        BoletusVoice.PlayOneShot(WhywhywhyPunch); yield return new WaitForSeconds(29);
        LeftHand.SetActive(true);
        RightHand.SetActive(true);
        BoletusVoice.PlayOneShot(CryMedium); yield return new WaitForSeconds(8);
        BoletusVoice.PlayOneShot(WhatAmIGoingToDo); yield return new WaitForSeconds(12);
        BoletusVoice.PlayOneShot(SheWasAlwaysThere); yield return new WaitForSeconds(48);
        LeftHand.SetActive(false);
        RightHand.SetActive(false);
        BoletusVoice.PlayOneShot(WhatsThatInHerPocket); yield return new WaitForSeconds(3);
        BoletusVoice.PlayOneShot(ABox); yield return new WaitForSeconds(1);
        BoletusVoice.PlayOneShot(SheWasGoingToPropose); yield return new WaitForSeconds(3);
        BoletusVoice.PlayOneShot(YES);
        RingBox.SetActive(false);
        RingOnFinger.SetActive(true);
        LeftHand.SetActive(true);
        RightHand.SetActive(true);
        yield return new WaitForSeconds(12);
        LeftHand.SetActive(false);
        RightHand.SetActive(false);
        BoletusVoice.PlayOneShot(WhatsThatSmell); yield return new WaitForSeconds(3);
        BoletusVoice.PlayOneShot(IShouldTurnTheStoveOff); yield return new WaitForSeconds(3);
        BoletusVoice.PlayOneShot(IdontWantToDoAnything); yield return new WaitForSeconds(3);
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
        if(!BoletusVoice.isPlaying)
        StartCoroutine(BoletusMonologue());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
