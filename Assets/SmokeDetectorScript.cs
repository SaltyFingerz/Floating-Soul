using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetectorScript : MonoBehaviour
{
    private AudioSource Alarm;
    // Start is called before the first frame update
    void Start()
    {
        Alarm = GetComponent<AudioSource>();
    }

    public void PlayAlarm()
    {
        Alarm.Play();
    }

    public void StopAlarm()
    {
        Alarm.Stop();
    }
}
