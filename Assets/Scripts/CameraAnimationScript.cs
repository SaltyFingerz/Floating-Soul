using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationScript : MonoBehaviour
{
    private Animator anim;
    public Animator EyeLidAnim;
    public static bool Vignetting;
    public static bool Desaturating;
    public static bool DecreaseVignette;
    public AudioClip Collapsing;
    public GameObject Boletus;
    public AudioSource CollapsingSound;

    [SerializeField] private AudioSource NormalBreathing;
    [SerializeField] private AudioSource heartAttack;

    [SerializeField] private AudioSource normalHeartbeat;

    [SerializeField] private AudioSource faster1Heartbeat;

    [SerializeField] private AudioSource faster2Heartbeat;
    [SerializeField] private AudioSource faster3Heartbeat;

    [SerializeField] private AudioSource fastestHeartAttack;

    public PostProcessingScript PPScript;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DyingRoutine5678());
          
           
        }

        if(Vignetting) {
            PPScript.IncreaseVignette();
        }
        else if( DecreaseVignette)
        {
            PPScript.DecreaseVignette();
        }
        else if (!Vignetting && !DecreaseVignette)
        {
            PPScript.ResetVignette();
        }

        if(Desaturating)
        {
            print("desaturating in update");
            PPScript.DecreaseSaturation();  
        }
        else if(!Desaturating)
        {
            PPScript.RestoreSaturation();
        }
    }

    IEnumerator DyingRoutine5678()
    {
        NormalBreathing.Stop();
        anim.SetTrigger("pain");
        
        EyeLidAnim.SetTrigger("Pain");
        Desaturating = true;
        heartAttack.Play();
        normalHeartbeat.Stop();
        faster1Heartbeat.Play();
        yield return new WaitForSeconds(5f);
        
        faster1Heartbeat.Stop();
        faster2Heartbeat.Play();
       
        yield return new WaitForSeconds(4f);
        faster2Heartbeat.Stop();
        faster3Heartbeat.Play();
        
        print("Desaturating" + Desaturating);
        yield return new WaitForSeconds(4f);
        PPScript.DecreaseSaturation();
        faster3Heartbeat.Stop();
        fastestHeartAttack.Play();
        Vignetting = true;
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("dead");
      
       

        
       
        

    }

    IEnumerator MomentOfDeath()
    {
        fastestHeartAttack.Stop();
        DeathScript.Dead = true;
        yield return null;
    }

    public void WelcomeBoletusEvent()
    {
        DeathScript.WelcomeBoletus = true;
    }

    public void CollapsingAudioEvent()
    {
        CollapsingSound.PlayOneShot(Collapsing);
    }

    public void HideBoletus()
    {
        Boletus.SetActive(false);
    }
}
