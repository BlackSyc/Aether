using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public struct Events
    {
        public static event Action<Companion> OnCompanionAdded;

        public static event Action OnCompanionRemoved;

        public static void CompanionAdded(Companion companion)
        {
            OnCompanionAdded?.Invoke(companion);
        }

        public static void CompanionRemoved()
        {
            OnCompanionRemoved?.Invoke();
        }
    }
    private Cloak equippedCloak;

    private void Start()
    {
        equippedCloak = Player.Instance.Shoulder.EquippedCloak;
        Player.Instance.Companion = this;
        Events.CompanionAdded(this);
        Cloak.Events.OnCloakUnequipped += CloakUnequipped;
    }

    private void CloakUnequipped(Cloak cloak)
    {
        if (cloak == equippedCloak)
        {
            Player.Instance.Companion = null;
            Destroy(gameObject);
            Events.CompanionRemoved();
        }
    }

    private void OnDestroy()
    {
        Cloak.Events.OnCloakUnequipped -= CloakUnequipped;
    }
}
