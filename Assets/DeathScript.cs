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

public class DeathScript : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    private ActionBasedContinuousMoveProvider aBCP; 
    private bool Dead = false;
    private ScriptableObject flyingScript;
    void Start()
    {
        aBCP = GetComponent<ActionBasedContinuousMoveProvider>();
    }


    void Update()
    {

        if (Dead)
        {
            LeftHand.SetActive(false);
            RightHand.SetActive(false);
            aBCP.enableFly = true;
        }
    }


    IEnumerator Dying()
    {
        yield return new WaitForSeconds(10f);
        Dead = true;
    }

}
