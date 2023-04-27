using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosessionScript : MonoBehaviour
{
    public Animator camAnim;
   
    // Start is called before the first frame update
    void Start()
    {
     camAnim = GetComponent<Animator>();  
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lady"))
        {
            print("inzone to possess");
            camAnim.SetTrigger("possess");
            DeathScript.Possessing = true;
            print("possessing" + DeathScript.Possessing);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("lady"))
        {
            print("inzone to possess");
            camAnim.SetTrigger("possess");
            DeathScript.Possessing = true;
            print("possessing" + DeathScript.Possessing);
        }
    }
}
