using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissileTarget : MonoBehaviour
{

    [SerializeField]
    private float resetAfter = 5;

    public bool IsHit { get; private set; }


    private void StopResetTimerAndMoveToCloakPosition()
    {
        GetComponent<Animator>().SetTrigger("MoveToCloakPosition");
        StopAllCoroutines();
    }

    private void MoveToCenter()
    {
        GetComponent<Animator>().SetTrigger("MoveToCenter");
    }

    private void MoveToOriginalPosition()
    {
        GetComponent<Animator>().SetTrigger("MoveToOriginalPosition");
    }

    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 += MoveToCenter;
        AetherEvents.GameEvents.Puzzle1Events.OnAspectOfCreationDialogComplete += MoveToOriginalPosition;
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage2 += StopResetTimerAndMoveToCloakPosition;
    }

    public void Hit()
    {
        if (IsHit)
            return;

        GetComponent<Animator>().SetBool("Hit", true);
        IsHit = true;
        gameObject.layer = LayerMask.NameToLayer("Obstruction");
        StopAllCoroutines();

        AetherEvents.GameEvents.Puzzle1Events.MissileTargetHit();

        StartCoroutine(ResetTimer(resetAfter));
    }

    private IEnumerator ResetTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        IsHit = false;
        gameObject.layer = LayerMask.NameToLayer("Target");
        GetComponent<Animator>().SetBool("Hit", false);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 -= MoveToCenter;
        AetherEvents.GameEvents.Puzzle1Events.OnAspectOfCreationDialogComplete -= MoveToOriginalPosition;
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage2 -= StopResetTimerAndMoveToCloakPosition;
    }
}
