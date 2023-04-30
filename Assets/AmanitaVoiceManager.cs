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
       
    }
}
