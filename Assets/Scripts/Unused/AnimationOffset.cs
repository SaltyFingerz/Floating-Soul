using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    public Animator animBoletus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animBoletus.GetCurrentAnimatorStateInfo(0).IsName("stand-crouchcryloop-f"))
        {
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1.53f, gameObject.transform.position.z);
        }
    }
}
