using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private TargetManager targetManager;

    [SerializeField]
    private RectTransform targetLock;

    [SerializeField]
    private GameObject targetTracker;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject crosshairContainer;

    [SerializeField]
    private Camera camera;

    private void Start()
    {
        AetherEvents.GameEvents.SpellSystemEvents.OnSelectSpell += SpellSelected;
    }

    private void SpellSelected(SpellSlot spellSlot, Spell spell)
    {
        if (spellSlot == null || spell == null)
            return;

        if (!crosshairContainer.activeSelf)
            crosshairContainer.SetActive(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(targetManager.GetCurrentTarget().HasTargetTransform)
        {
            if (targetManager.HasLockedTarget && targetManager.GetCurrentTarget().TargetTransform == targetManager.Target.TargetTransform)
            {
                animator.SetBool("HasObjectTarget", false);
            }
            else
            {
                animator.SetBool("HasObjectTarget", true);
            }
        }
        else
        {
            animator.SetBool("HasObjectTarget", false);
        }

        if (targetManager.HasLockedTarget)
        {
            targetTracker.SetActive(true);
            targetTracker.GetComponent<RectTransform>().position = camera.WorldToScreenPoint(targetManager.Target.Position);
        }
        else
        {
            targetTracker.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.SpellSystemEvents.OnSelectSpell -= SpellSelected;
    }
}
