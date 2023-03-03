using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();
    private Rigidbody rigidbody;
    private bool isInReplayMode;
    private int currentReplayIndex;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isInReplayMode = !isInReplayMode; //i did not know you could do that

            if (isInReplayMode)
            {
                SetTransform(0); //entering replay mode sets transform to first frame. How to make it loop?
                rigidbody.isKinematic = true;
            }    
            else
            {
                SetTransform(actionReplayRecords.Count - 1); //exiting replay mode sets transform to the last frame. I think I want to exit replay mode onto the current frame though.
                rigidbody.isKinematic = false; 
            }
        }
    }

    private void FixedUpdate()
    {
        if (isInReplayMode == false)
        {
            actionReplayRecords.Add(new ActionReplayRecord { position = transform.position, rotation = transform.rotation });
        }
        else
        {
            int nextIndex = currentReplayIndex + 1;
            if (nextIndex < actionReplayRecords.Count)
            {
                SetTransform(nextIndex);
            }
        }
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;
        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];
        transform.position = actionReplayRecord.position;
        transform.rotation = actionReplayRecord.rotation;
    }
}
