using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class OrbHandIOverlapScript : MonoBehaviour
{
    // Start is called before the first frame update
    public BoletusInternalMonologue Monologue;
    InputDevice targetDevice;
    private XRController xr;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics desiredCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;

        // Get all devices that match the desired characteristics
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void SendHapticEvent(float amplitude, float duration)
    {
        // Check if the target device is valid
        if (targetDevice != null)
        {
            // Send the haptic impulse
            targetDevice.SendHapticImpulse(0, amplitude, duration);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("boletus"))
        {
            print("orb hand overlapped");
            Monologue.AAMonologue();
            SendHapticEvent(1f, 2f);

        }
    }
   

}
