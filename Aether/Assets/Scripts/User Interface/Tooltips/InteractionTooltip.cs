using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;


    public void Activate(string message)
    {
        text.text = message;
        GetComponent<Animator>().SetBool("Shown", true);
    }

    public void Deactivate()
    {
        GetComponent<Animator>().SetBool("Shown", false);
    }

    public void PerformAnimation()
    {
        GetComponent<Animator>().SetTrigger("Performed");
    }
}
