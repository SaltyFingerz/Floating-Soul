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
        yield return new WaitForSeconds(7);
       // PromptEnter.SetActive(true);
        MindOpen = true;
        print("mind open" + MindOpen);

    }

    public void DeactivatePrompt()
    {
        PromptEnter.SetActive(false);
    }
}
