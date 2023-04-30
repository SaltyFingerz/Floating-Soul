using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVoiceTriggers : MonoBehaviour
{
    public AmanitaVoiceManager voiceManager;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kettle"))
        {
            AmanitaVoiceManager.isTouchingKettle = true;
            voiceManager.PuttingKettleOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("kettle"))
        {
            AmanitaVoiceManager.isTouchingKettle = false;

        }
    }
}
