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

        Cloak.Events.OnCloakEquipped += CloakEquipped;
        Cloak.Events.OnCloakUnequipped += CloakUnequipped;
    }

    private void CloakEquipped(Cloak cloakInfo)
    {
        if (cloakInfo.Aspect.Equals(aspect))
        {
            interactable.IsActive = true;
            animator.SetBool("activated", true);
        }
    }

    private void CloakUnequipped(Cloak cloakInfo)
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
        Cloak.Events.OnCloakEquipped -= CloakEquipped;
        Cloak.Events.OnCloakUnequipped -= CloakUnequipped;
    }
}
