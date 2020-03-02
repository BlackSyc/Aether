using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogCallback
{
    public UnityEvent DialogComplete;

    public DialogCallback()
    {
        DialogComplete = new UnityEvent();
    }
}

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

    

    public DialogCallback StartDialog(List<string> dialogLines)
    {
        DialogCallback callBack = new DialogCallback();
        StartCoroutine(DialogCoroutine(dialogLines, callBack));
        return callBack;
    }

    private IEnumerator DialogCoroutine(List<string> dialogLines, DialogCallback callBack)
    {
        foreach(string dialogLine in dialogLines)
        {
            dialogText.text = dialogLine;
            animator.SetBool("ShowText", true);
            yield return new WaitForSeconds(dialogLineDuration);

            animator.SetBool("ShowText", false);
            yield return new WaitForSeconds(dialogLineTransitionDuration);
            //callBack.LineComplete.Invoke(dialogLine);

        }
        callBack.DialogComplete.Invoke();
    }
}
