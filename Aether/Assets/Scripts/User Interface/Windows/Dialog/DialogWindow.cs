using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogText;

    [SerializeField]
    [Min(1f)]
    private float dialogLineDuration = 1f;

    [SerializeField]
    [Min(1f)]
    private float dialogLineTransitionDuration = 1f;

    [SerializeField]
    private Animator animator;

    

    public void StartDialog(List<string> dialogLines)
    {
        StartCoroutine(DialogCoroutine(dialogLines));
    }

    private IEnumerator DialogCoroutine(List<string> dialogLines)
    {
        foreach(string dialogLine in dialogLines)
        {
            dialogText.text = dialogLine;
            animator.SetBool("ShowText", true);
            yield return new WaitForSeconds(dialogLineDuration);

            animator.SetBool("ShowText", false);
            yield return new WaitForSeconds(dialogLineTransitionDuration);

        }
    }
}
