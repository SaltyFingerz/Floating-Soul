using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KettleScript : MonoBehaviour
{
    public ParticleSystem Steam;
    AudioSource SteamSFX;
    public AmanitaVoiceManager AmanitaVoice;
    [SerializeField] private float _emissionRateIncreaseRate;
    [SerializeField] private float _timeToIncreaseEmissionRate;
    private Rigidbody rb;
    private float _timeElapsed;
    public static bool boiled;

    private void Start()
    {
        SteamSFX = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (AmanitaVoiceManager.isOnStove)
        {
            StartCoroutine(IncreaseSteamGradually());
        }
      
    }

  IEnumerator IncreaseSteamGradually()
    {
        SteamSFX.volume = 0.05f;
        var emission = Steam.emission;
        emission.rateOverTime = 2;
        yield return new WaitForSeconds(10);
        emission.rateOverTime = 5;
        yield return new WaitForSeconds(2);
        SteamSFX.volume = 0.1f;
        emission.rateOverTime = 10;
     //   SteamSFX.volume = 0.3f;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 15;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 20;
        SteamSFX.volume = 0.15f;
        //   SteamSFX.volume = 0.4f;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 30;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 40;
        SteamSFX.volume = 0.2f;
        //   SteamSFX.volume = 0.5f;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 50;
        yield return new WaitForSeconds(2);
        emission.rateOverTime = 60;
        SteamSFX.volume = 0.3f;
        //   SteamSFX.volume = 0.6f;
        yield return new WaitForSeconds(2);
        SteamSFX.volume = 0.4f;
        emission.rateOverTime = 80;
     //   SteamSFX.volume = 0.8f;
        yield return new WaitForSeconds(10);
        SteamSFX.volume = 0.5f;
        emission.rateOverTime = 100;

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("hob"))
        {
            boiled = true;
            Steam.Play();
            _timeElapsed = 0f;
            AmanitaVoiceManager.isOnStove = true;
            AmanitaVoice.PromptToast();
            StartCoroutine(FreezeKettle());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("hob"))
        {
            Steam.Stop();
            AmanitaVoiceManager.isOnStove = false;
        }
    }

    IEnumerator FreezeKettle()
    {
        yield return new WaitForSeconds(4);
        Quaternion.Euler(Vector3.zero);
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(10);
        if (!SteamSFX.isPlaying)
        {
            SteamSFX.Play();
        }
    }

}
