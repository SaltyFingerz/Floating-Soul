using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSu : MonoBehaviour
{
    public GameObject PromptEnter;

    public static bool MindOpen;
    public void ShowPromptEnter()
    {
        StartCoroutine(WaitToCry());
    }

    IEnumerator WaitToCry()
    {
        yield return new WaitForSeconds(3);
        PromptEnter.SetActive(true);
        MindOpen = true;

    }

    public void DeactivatePrompt()
    {
        PromptEnter.SetActive(false);
    }
}
