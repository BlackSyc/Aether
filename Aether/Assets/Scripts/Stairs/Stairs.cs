using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{

    [SerializeField]
    private Aspect aspect;

    [SerializeField]
    private Interactable interactable;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        AetherEvents.GameEvents.CloakEvents.OnCloakEquipped += CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped += CloakUnequipped;
    }

    private void CloakEquipped(CloakInfo cloakInfo)
    {
        if (cloakInfo.Aspect.Equals(aspect))
        {
            interactable.IsActive = true;
            animator.SetBool("activated", true);
        }
    }

    private void CloakUnequipped(CloakInfo cloakInfo)
    {
        if (cloakInfo.Aspect.Equals(aspect))
        {
            interactable.IsActive = false;
            animator.SetBool("activated", false);
            AetherEvents.GameEvents.HubEvents.CloseStairs(aspect);
        }
    }

    public void MoveStairs()
    {
        animator.SetTrigger("move");
        interactable.IsActive = false;
        AetherEvents.GameEvents.HubEvents.OpenStairs(aspect);
    }



    // Update is called once per frame
    void OnDestroy()
    {
        AetherEvents.GameEvents.CloakEvents.OnCloakEquipped -= CloakEquipped;
        AetherEvents.GameEvents.CloakEvents.OnCloakUnequipped -= CloakUnequipped;
    }
}
