using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHandIOverlapScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoletusInternalMonologue Monologue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("boletus"))
        {
            print("orb hand overlapped");
            Monologue.AAMonologue();

        }
    }

    
}
