using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    public DeathScript deathScript;
    public Animator animBoletus;
    public Animator animDoor;
    // Start is called before the first frame update
    void Start()
    {
        deathScript = gameObject.GetComponent<DeathScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(DeathScript.WelcomeBoletus)
        {
            StartCoroutine(waitToWalk());
        }
    }

    IEnumerator waitToWalk()
    {
        yield return new WaitForSeconds(2);
        animDoor.SetTrigger("Open");
        yield return new WaitForSeconds(1);
        animBoletus.SetTrigger("Walk");

    }
}
