using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField]
    private CloakInfo cloakInfo;

    private Interactable interactable;

    private Animator animator;
    void Start()
    {
        interactable = GetComponent<Interactable>();
        animator = GetComponent<Animator>();

        AetherEvents.GameEvents.CloakEvents.OnCloakEquipped += CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped += CloakUnequipped;
    }

    private void CloakEquipped(CloakInfo cloakInfo)
    {
        if (cloakInfo == this.cloakInfo)
        {
            interactable.IsActive = true;
            animator.SetBool("activated", true);
        }
    }

    private void CloakUnequipped(CloakInfo cloakInfo)
    {
        if (cloakInfo == this.cloakInfo)
        {
            interactable.IsActive = false;
            animator.SetBool("activated", false);
        }
    }

    public void MoveStairs()
    {
        animator.SetTrigger("move");
        interactable.IsActive = false;
    }



    // Update is called once per frame
    void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnCloakEquipped -= CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped -= CloakUnequipped;
    }
}
