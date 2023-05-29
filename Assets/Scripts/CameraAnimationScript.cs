using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Video;
using UnityEngine.UI;


public class CameraAnimationScript : MonoBehaviour
{
    public DirectorScript Director;
    private Animator anim;
    public Animator EyeLidAnim;
    public BoletusBodyVoiceScript BoletusVoice;
    public BoletusInternalMonologue BoletusInternal;
    public ActionBasedContinuousMoveProvider aBCP;
    public static bool Vignetting;
    public static bool Desaturating;
    public static bool DecreaseVignette;
    public AudioClip Collapsing;
    public GameObject Boletus;
    public AudioSource CollapsingSound;
    public AudioSource BreathingFast;
    public AudioSource Screaming;
    public AudioClip Scream1;
    public AudioClip Scream2;
    public AudioClip Scream3;
    public GameObject MainCam;
    public GameObject VidCam;
    [SerializeField] private AudioSource NormalBreathing;
    [SerializeField] private AudioSource heartAttack;

    [SerializeField] private AudioSource normalHeartbeat;

    [SerializeField] private AudioSource faster1Heartbeat;

    [SerializeField] private AudioSource faster2Heartbeat;
    [SerializeField] private AudioSource faster3Heartbeat;

    [SerializeField] private AudioSource fastestHeartAttack;

    public PostProcessingScript PPScript;


    public RawImage VideoScreen;
    public VideoPlayer Video;
   






    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        Video.loopPointReached += OnVideoPlaybackComplete;
        Cursor.visible = false;
     
    }

    void OnVideoPlaybackComplete(VideoPlayer vp)
    {
        VideoScreen.enabled = false; // Hide the RawImage when video playback completes
        MainCam.SetActive(true);
        VidCam.SetActive(false);
    }

    public void PlayVideo()
    {
        if (!Video.isPlaying)
        {
           
            VidCam.SetActive(true);
            Video.Play(); // Start playing the video
            MainCam.SetActive(false);
        }
    }

    public void DanDanDan()
    {
        StartCoroutine(DyingRoutine5678());
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayVideo();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            DanDanDan();
           
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
        anim.SetBool("pain", true);
        
        EyeLidAnim.SetTrigger("Pain");
        Desaturating = true;
        BreathingFast.Play();
        normalHeartbeat.Stop();
        faster1Heartbeat.Play();
        yield return new WaitForSeconds(5f);
        heartAttack.Play();
        
        
        faster1Heartbeat.Stop();
        faster2Heartbeat.Play();
       
        yield return new WaitForSeconds(4f);
        faster2Heartbeat.Stop();
        faster3Heartbeat.Play();
        PPScript.IncreaseDoF();
        
        print("Desaturating" + Desaturating);
        yield return new WaitForSeconds(4f);
        PPScript.DecreaseSaturation();
        faster3Heartbeat.Stop();
        BreathingFast.Stop();
        fastestHeartAttack.Play();
        Vignetting = true;
        
        yield return new WaitForSeconds(9f);
        Screaming.PlayOneShot(Scream1);
        anim.SetBool("pain", false);
        anim.SetBool("dead", true);
        //yield return new WaitForSeconds(1f);
        //Screaming.PlayOneShot(Scream2);
        
        //yield return new WaitForSeconds(1f);
        //Screaming.PlayOneShot(Scream3);
        
      
       

        
       
        

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
        Director.WalkGirl();
        PPScript.RegularVision();
        aBCP.moveSpeed = 1;

     //   BoletusVoice.AmanitaCallingByB();

    }

    public void BoletusHeart()
    {
        normalHeartbeat.Play();
    }

    public void CollapsingAudioEvent()
    {
        CollapsingSound.PlayOneShot(Collapsing);
    }

    bool hidingBoletus = false;
    public void HideBoletus()
    {
      
        if (Boletus.activeSelf && !hidingBoletus)
        {
            aBCP.moveSpeed = 0;
            StartCoroutine(HideBoletusTime());

        }

    }

    IEnumerator HideBoletusTime()
    {
        hidingBoletus = true;
        yield return new WaitForSeconds(2);
        DeathScript.Possessing = true;
        Boletus.SetActive(false);
        BoletusInternal.StartBoletusMonologue();
    }
}
