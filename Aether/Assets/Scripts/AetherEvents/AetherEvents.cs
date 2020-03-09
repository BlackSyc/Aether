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
            public static event Action<Spell> OnGrantNewSpell;
            public static event Action<Spell> OnNewSpellSelected;
            public static event Action<SpellCast> OnCastSpell;

            public static void GrantNewSpell(Spell spell)
            {
                OnGrantNewSpell?.Invoke(spell);
            }

            public static void NewSpellSelected(Spell spell)
            {
                OnNewSpellSelected?.Invoke(spell);
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
            public static event Action<CloakInfo> OnEquipCloak;
            public static event Action OnUnequipCloak;
            public static event Action<CloakInfo> OnCloakEquipped;
            public static event Action<CloakInfo> OnCloakUnequipped;

            public static void CloakUnequipped(CloakInfo cloakInfo)
            {
                OnCloakUnequipped?.Invoke(cloakInfo);
            }

            public static void CloakEquipped(CloakInfo cloakInfo)
            {
                OnCloakEquipped?.Invoke(cloakInfo);
            }

            public static void ShowCloakInfo(CloakInfo cloakInfo)
            {
                OnShowCloakInfo?.Invoke(cloakInfo);
            }

            public static void HideCloakInfo()
            {
                OnHideCloakInfo?.Invoke();
            }

            public static void EquipCloak(CloakInfo cloakInfo)
            {
                OnEquipCloak?.Invoke(cloakInfo);
            }

            public static void UnequipCloak()
            {
                OnUnequipCloak?.Invoke();
            }
        }
    
        public struct Puzzle1Events 
        {
            public static event Action OnPressurePlateTriggered;
            public static event Action OnCompleteStage1;
            public static event Action OnAspectOfCreationDialogComplete;
            public static event Action OnMissileTargetHit;
            public static event Action OnCompleteStage2;
            

            public static void CompleteStage2()
            {
                OnCompleteStage2?.Invoke();
            }

            public static void AspectOfCreationDialogComplete()
            {
                OnAspectOfCreationDialogComplete?.Invoke();
            }

            public static void CompleteStage1()
            {
                OnCompleteStage1?.Invoke();
            }

            public static void PressurePlateTriggered()
            {
                OnPressurePlateTriggered?.Invoke();
            }

            public static void MissileTargetHit()
            {
                OnMissileTargetHit?.Invoke();
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
