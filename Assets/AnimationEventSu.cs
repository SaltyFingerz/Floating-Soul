using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSu : MonoBehaviour
{
    public GameObject PromptEnter;


    public void ShowPromptEnter()
    {
        StartCoroutine(WaitToCry());
    }

    IEnumerator WaitToCry()
    {
        yield return new WaitForSeconds(3);
        PromptEnter.SetActive(true);

    }
}
