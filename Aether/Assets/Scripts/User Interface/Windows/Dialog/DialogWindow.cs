using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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

    

    public void StartDialog(Dialog dialog)
    {
        StartCoroutine(DialogCoroutine(dialog));
    }

    private IEnumerator DialogCoroutine(Dialog dialog)
    {
        foreach(DialogLine dialogLine in dialog.dialogLines)
        {
            dialogText.text = dialogLine.Content;
            animator.SetBool("ShowText", true);
            yield return new WaitForSeconds(dialogLineDuration);

            animator.SetBool("ShowText", false);
            yield return new WaitForSeconds(dialogLineTransitionDuration);
            dialogLine.Complete();

        }
        dialog.Complete();
    }
}
