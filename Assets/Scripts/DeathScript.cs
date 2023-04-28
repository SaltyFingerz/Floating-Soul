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
using static UnityEngine.GraphicsBuffer;

public class DeathScript : MonoBehaviour
{
    public PostProcessingScript PPScript;

    public GameObject LeftHand;
    public GameObject RightHand;
    public AudioClip AmbientAudio;
   
    public GameObject GhostHandLeft;
    public GameObject GhostHandRight;
    public GameObject EyeLids;
    //public GameObject LivingAmbience;
    public GameObject Corpse;
    public Image Blind;
    public GameObject LightObj;
    private Image Light;
    private ActionBasedContinuousMoveProvider aBCP; 
    public static bool Dead = false;
    public static bool Possessing = false;
    private ScriptableObject flyingScript;
    public AudioSource BirdsAudio;
    public AudioSource MachineAudio;
    public AudioSource Ambience;
    public Animator EyeLidAnim;
    public Animator CamAnim;
    public float fadeInTime = 20f; // Time in seconds for the fade-in effect
    private float alpha;
    private float alphaLight;
    public CameraRaycastScript CamRay;

    public float fadeDuration = 10f; // duration of the fade in seconds
  
    private float initialVolume;
    private float initialVolume2;

    bool Died = false;


    public Transform target;
    public float speed;

    public static bool WelcomeBoletus;
    public static bool Darken;
    public static bool Lighten;
    public static bool ResetPostExp;

    public void StartFadeOut()
    {
        BirdsAudio.volume = initialVolume;
        BirdsAudio.Play();

        MachineAudio.volume = initialVolume2;
        MachineAudio.Play();
    }

    public void StartFadeIn()
    {
        Ambience.volume = 0.05f;
        Ambience.Play();
    }

    void Start()
    {
        Light = LightObj.GetComponent<Image>();
        aBCP = GetComponent<ActionBasedContinuousMoveProvider>();
       // StartCoroutine(Dying());
        GhostHandLeft.SetActive(false);
        GhostHandRight.SetActive(false);
        Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, 0f); // Set the alpha value of the Image color to 0
        Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, 0f);
        initialVolume = BirdsAudio.volume;
        initialVolume2 = MachineAudio.volume;

    }


    void Update()
    {
        print("darken" + Darken);
        print("lighten" + Lighten);
        print("ResetPExp" + ResetPostExp);

        if(increaseSpotLight)
        {
            LightSize();
            LightOpacity();
        }

        if(isLosingHearing) { LosingHearing(); }

        print("lighten" + Lighten);

        if(Darken) {

            PPScript.DecreasePostExp();
        }

        if(Lighten)
        {
            Darken = false;
            PPScript.IncreasePostExp();
        }

        if(ResetPostExp)
        {
            Lighten = false;
            Darken = false;
            PPScript.ResetPostExp();
        }

        if (Dead)
        {
            LeftHand.SetActive(false);
            RightHand.SetActive(false);
            GhostHandLeft.SetActive(true);
            GhostHandRight.SetActive(true);
            aBCP.enableFly = true;
            
            EyeLidAnim.SetTrigger("Dead");
             if (!Died)
               {
            StartCoroutine(FadeIn());
            }

        }

        if( Possessing)
        {
            StartCoroutine(PossessingTime());
        }

        IEnumerator PossessingTime()
        {
            ResetPostExp = true;
            Lighten = false;
            increaseSpotLight = false;
            LightObj.SetActive(false);

            Dead = false;
            yield return new WaitForSeconds(2);
            LeftHand.SetActive(true);
            RightHand.SetActive(true);
            GhostHandLeft.SetActive(false);
            GhostHandRight.SetActive(false);
            aBCP.enableFly = false;
            EyeLids.SetActive(true);
            EyeLidAnim.SetTrigger("Blink");
            Possessing = false;
        }



        if(CameraRaycastScript.LookingSu)
        {
            if (AnimationEventSu.MindOpen)
            {
                Lighten = true;
                Darken = false;
                increaseSpotLight = true;
                // Calculate the direction to the target
                Vector3 direction = target.position - transform.position;

                // Calculate the distance to the target
                float distance = direction.magnitude;

                // Normalize the direction to get a unit vector
                direction.Normalize();

                // If the distance is greater than zero, move towards the target
                if (distance > 0)
                {
                    transform.position += direction * speed * Time.deltaTime;
                }
            }
        }
       
 
    }


 private void LosingHearing()
    {
       
        if (BirdsAudio.volume > 0f)
        {
            BirdsAudio.volume -= Time.deltaTime *0.05f;
        }
        else
        {
            BirdsAudio.volume = 0f;
            BirdsAudio.Stop();

        }

        if (MachineAudio.volume > 0f)
        {
            MachineAudio.volume -= Time.deltaTime *0.05f ;
        }
        else
        {
            MachineAudio.volume = 0f;
            MachineAudio.Stop();

        }

        // Start the coroutine to fade in the Image over time
       // StopCoroutine(LosingHearing());
        
    }
    private bool increaseSpotLight;
    private bool isLosingHearing;
    private IEnumerator FadeIn()
    {
        Darken = true;
     /*   while (alpha < 1)
        {
            Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, alpha);
            alpha += 0.5f * Time.deltaTime;
            yield return null;

        }
        Blind.color = new Color(Blind.color.r, Blind.color.g, Blind.color.b, 1f);
     */
        Died = true;
        EyeLids.SetActive(false);
        isLosingHearing = true;
        yield return new WaitForSeconds(4);


        
        increaseSpotLight = true;
        CamAnim.SetBool("dead", false);
        Lighten = true;
        Darken = false;
        increaseSpotLight = true;
      

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
       
       
    }
    private void LightSize()
    {
       
        CameraAnimationScript.Desaturating = false;
        Vector3 growthIncrement = new Vector3(.2f, .2f, .2f);
        if (LightObj.transform.localScale.x < 1)
        {

            LightObj.transform.localScale += growthIncrement * Time.deltaTime *2;
            
        }
        else if (LightObj.transform.localScale.x > 1)
        {
            LightObj.transform.localScale = new Vector3(1, 1, 1);

        }
        if (LightObj.transform.localScale.x > .3f)
        {
            CameraAnimationScript.Vignetting = false;
            CameraAnimationScript.DecreaseVignette = true;
            
           

        }
    }
   private void LightOpacity()
    {
        Ambience.PlayOneShot(AmbientAudio);

        LightObj.SetActive(true);
        if (alphaLight < 1)
        {

            Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, alphaLight);
            alphaLight += 0.1f * Time.deltaTime*100;


        }
        else {
            Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, 1f);
        }
      
        
       // StartCoroutine(FadeOut());

       
        if (alphaLight > 0.9f && LightObj.transform.localScale.x > .3f)
        {
            CameraAnimationScript.Vignetting = false;
            CameraAnimationScript.DecreaseVignette = true;
           
            StartCoroutine(LightFadeOut());
        }
        
        
        
    }

    private bool risen;
    private IEnumerator LightFadeOut()
    {
       
        //CameraAnimationScript.DecreaseVignette = true;
        
       
        Darken = false;
        
        while (alphaLight > 0)
        {
            Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, alphaLight);
            alphaLight -= 0.01f * Time.deltaTime * 2;
            yield return null;

        }
        Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, 0f);
        ResetPostExp = true;
      Lighten = false;
        yield return new WaitForSeconds(3);
        Corpse.SetActive(true);
        if (!risen)
        {
            CamAnim.SetBool("pain", false);
            CamAnim.SetBool("rise", true);
            yield return new WaitForSeconds(1);
            CamAnim.SetBool("rise", false);
            print("rise trigger being set");
            risen = true;
        }

       
        yield return null; 
        //CameraAnimationScript.DecreaseVignette = false;
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lady"))
        {
           
            CamAnim.SetBool("possess", true);
          
           
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("lady"))
        {
           
            CamAnim.SetBool("possess", true);
          
            
        }
    }

}
