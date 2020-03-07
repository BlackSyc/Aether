using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissileTarget : MonoBehaviour
{
    [SerializeField]
    private Puzzle1_Manager puzzle1Manager;

    [SerializeField]
    private float resetAfter = 5;

    public bool IsHit { get; private set; }


    public void MoveToCloakPosition()
    {
        GetComponent<Animator>().SetTrigger("MoveToCloakPosition");
    }

    public void MoveToCenter()
    {
        GetComponent<Animator>().SetTrigger("MoveToCenter");
    }

    public void MoveToOriginalPosition()
    {
        GetComponent<Animator>().SetTrigger("MoveToOriginalPosition");
    }

    public void Hit()
    {
        if (IsHit)
            return;

        GetComponent<Animator>().SetBool("Hit", true);
        IsHit = true;
        gameObject.layer = LayerMask.NameToLayer("Obstruction");
        StopAllCoroutines();

        if(!puzzle1Manager.TryCompleteStage2())
            StartCoroutine(ResetTimer(resetAfter));
    }

    private IEnumerator ResetTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (puzzle1Manager.Stage2Complete)
            yield break;

        IsHit = false;
        gameObject.layer = LayerMask.NameToLayer("Target");
        GetComponent<Animator>().SetBool("Hit", false);
    }
}
