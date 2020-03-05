using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator animator;


    public void Activate(string message)
    {
        text.text = message;
        animator.SetBool("Shown", true);
    }

    public void Deactivate()
    {
        animator.SetBool("Shown", false);
    }

    public void PerformAnimation()
    {
        animator.SetTrigger("Performed");
    }
}
