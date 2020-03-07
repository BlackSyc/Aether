using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherEvents : MonoBehaviour
{

    public struct GameEvents
    {
        public struct InteractionEvents 
        {
            public static event Action<Interactable> OnProposeInteraction;
            public static event Action OnCancelProposeInteraction;
            public static event Action OnInteract;

            public static void ProposeInteraction(Interactable interactable)
            {
                OnProposeInteraction?.Invoke(interactable);
            }

            public static void CancelProposeInteraction()
            {
                OnCancelProposeInteraction?.Invoke();
            }

            public static void Interact()
            {
                OnInteract?.Invoke();
            }
        }
    
        public struct DialogEvents 
        {
            public static event Action<Dialog> OnStartDialog;

            public static void StartDialog(Dialog dialog)
            {
                OnStartDialog?.Invoke(dialog);
            }
        }

        public struct SpellSystemEvents 
        {
            public static event Action<SpellSlot, Spell> OnSelectSpell;
            public static event Action<SpellCast> OnCastSpell;

            public static void SelectSpell(SpellSlot spellSlot, Spell spell)
            {
                OnSelectSpell?.Invoke(spellSlot, spell);
            }
            public static void CastSpell(SpellCast spellCast)
            {
                OnCastSpell?.Invoke(spellCast);
            }
        }

        public struct CloakEvents 
        {
            public static event Action<CloakInfo> OnShowCloakInfo;
            public static event Action OnHideCloakInfo;
            public static event Action<GameObject> OnEquipCloak;
            public static event Action OnUnequipCloak;

            public static void ShowCloakInfo(CloakInfo cloakInfo)
            {
                OnShowCloakInfo?.Invoke(cloakInfo);
            }

            public static void HideCloakInfo()
            {
                OnHideCloakInfo?.Invoke();
            }

            public static void EquipCloak(GameObject cloakPrefab)
            {
                OnEquipCloak?.Invoke(cloakPrefab);
            }

            public static void UnequipCloak()
            {
                OnUnequipCloak?.Invoke();
            }
        }
    
        public struct Puzzle1Events 
        {
            public static event Action OnShowCloaks;

            public static void ShowCloaks()
            {
                OnShowCloaks?.Invoke();
            }
        }
    }

    public struct UIEvents
    {
        public struct ToolTips 
        {
            public static event Action OnHideAll;
            public static event Action OnUnhideAll;

            public static void HideAll()
            {
                OnHideAll?.Invoke();
            }

            public static void UnhideAll()
            {
                OnUnhideAll?.Invoke();
            }
        }
    }
}
