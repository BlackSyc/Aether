﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField]
    private Aspect aspect;

    [SerializeField]
    private Leaf leaf;

    public Aspect Aspect => aspect;

    [SerializeField]
    private Interactable interactable;

    private Animator animator;

    [SerializeField]
    private Keystone grantKeystone;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.keepAnimatorControllerStateOnDisable = true;

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
            leaf.DespawnPlatform();
        }
    }

    public void MoveStairs()
    {
        Hint.Get("Cursor").Activate();
        animator.SetTrigger("move");
        interactable.IsActive = false;
        leaf.SpawnPlatform();

        GrantKeystone();
    }

    private void GrantKeystone()
    {
        if(grantKeystone != null)
        {
            Player.Instance.Inventory.PickupKeystone(grantKeystone);
            grantKeystone = null;
        }
    }



    // Update is called once per frame
    void OnDestroy()
    {
        Cloak.Events.OnCloakEquipped -= CloakEquipped;
        Cloak.Events.OnCloakUnequipped -= CloakUnequipped;
    }
}
