using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostHandControlsScript : MonoBehaviour
{
    public InputActionProperty floatAmount;
    public bool LeftHand;
    public GameObject TheBody;
    public float movementSpeed = 0.5f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftHand)
        {
            float triggerValue = floatAmount.action.ReadValue<float>();
            TheBody.transform.position += new Vector3(0, triggerValue * movementSpeed * Time.deltaTime, 0);
           
        }

        else
        {
            float triggerValue = floatAmount.action.ReadValue<float>();
            TheBody.transform.position -= new Vector3(0, triggerValue * movementSpeed * Time.deltaTime, 0);
            
        }
    }
}
