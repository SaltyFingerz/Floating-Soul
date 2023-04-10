using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    public float amp;
    public float freq;
    public float ampHor;
    public float freqHor;
 
    public float ampDep;
    public float freqDep;
    Vector3 initPos;
    private void Start()
    {
        initPos = transform.position;

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * freq) * amp + transform.position.y, transform.position.z);

    }
   
}
