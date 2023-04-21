using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Unity.XR.CoreUtils;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;

    public GameObject GhostHandLeft;
    public GameObject GhostHandRight;
    public GameObject EyeLids;
    //public GameObject LivingAmbience;
    public GameObject Corpse;
    public Image Blind;
    public Image Light;
    private ActionBasedContinuousMoveProvider aBCP; 
    public static bool Dead = false;
    private ScriptableObject flyingScript;
    public AudioSource BirdsAudio;
    public AudioSource MachineAudio;
    public Animator EyeLidAnim;
    public Animator CamAnim;
    public float fadeInTime = 20f; // Time in seconds for the fade-in effect
    private float alpha;
    

    public float fadeDuration = 10f; // duration of the fade in seconds
  
    private float initialVolume;

    bool Died = false;
        
   



    public void StartFadeOut()
    {
        BirdsAudio.volume = initialVolume;
        BirdsAudio.Play();
    }


    void Start()
    {
        aBCP = GetComponent<ActionBasedContinuousMoveProvider>();
       // StartCoroutine(Dying());
        GhostHandLeft.SetActive(false);
        GhostHandRight.SetActive(false);
        Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, 0f); // Set the alpha value of the Image color to 0

        initialVolume = BirdsAudio.volume;

    }


    void Update()
    {
        print(BirdsAudio.volume);
        if (Dead)
        {
            LeftHand.SetActive(false);
            RightHand.SetActive(false);
            GhostHandLeft.SetActive(true);
            GhostHandRight.SetActive(true);
            aBCP.enableFly = true;
            Corpse.SetActive(true);

           // if (!Died)
         //   {
                StartCoroutine(LosingSenses());
          //  }

        }

 
    }


 IEnumerator LosingSenses()
    {
       
        EyeLidAnim.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        //  StartCoroutine(AudioFadeOut.FadeOut(BirdsAudio, 20f));
        //  StartCoroutine(AudioFadeOut.FadeOut(MachineAudio, 20f));
        //  yield return new WaitForSeconds(2f);

        if (BirdsAudio.volume > 0f)
        {
            BirdsAudio.volume -= Time.deltaTime / (fadeDuration*100);
        }
        else
        {
            BirdsAudio.volume = 0f;
            BirdsAudio.Stop();
            if (!Died)
            {
                StartCoroutine(FadeIn());
            }
        }

        // Start the coroutine to fade in the Image over time
        StopCoroutine(LosingSenses());
       
        yield return new WaitForSeconds(2);
       // EyeLids.SetActive(false);
    }
    private IEnumerator FadeIn()
    {
       
        while (alpha < 1)
        {
            Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, alpha);
            alpha += 0.5f * Time.deltaTime;
            yield return null;

        }
        Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, 1f);
        Died = true;
        EyeLids.SetActive(false);
        yield return new WaitForSeconds(3);
        StartCoroutine (FadeOut());
       
        StopCoroutine(FadeIn());
     
        
    }

    private IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, alpha);
            alpha -= 0.5f * Time.deltaTime;
            yield return null;

        }
        Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, 0f);
        yield return new WaitForSeconds (3);
        CamAnim.SetTrigger("rise");
    }    

   /* public IEnumerator FadeIn(Image a_image)
        {
            a_image.enabled = true;
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                a_image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
   */



}
