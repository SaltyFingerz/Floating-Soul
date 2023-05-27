using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    public DeathScript deathScript;
    public Animator animBoletus;
    public Animator animDoor;
    public BoletusBodyVoiceScript Boletus;
    // Start is called before the first frame update
    void Start()
    {
        deathScript = gameObject.GetComponent<DeathScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //if(DeathScript.WelcomeBoletus)
        //{
        //    StartCoroutine(waitToWalk());
        //}
    }

    IEnumerator waitToWalk()
    {
        Boletus.CallingRoute();
        yield return new WaitForSeconds(2);
        animDoor.SetTrigger("Open");
        animBoletus.SetTrigger("Walk");

    }

    public void WalkGirl()
    {
        StartCoroutine (waitToWalk());
    }
}
