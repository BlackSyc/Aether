using System.Collections;
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

    private void Start()
    {
        Dialog.Events.OnStartDialog += StartDialog;
    }

    private void StartDialog(Dialog dialog)
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

    private void OnDestroy()
    {
        Dialog.Events.OnStartDialog -= StartDialog;
    }
}
