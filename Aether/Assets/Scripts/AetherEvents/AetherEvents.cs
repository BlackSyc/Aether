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
            public static event Action<string> OnShowInteraction;
            public static event Action OnHideInteraction;
            public static event Action OnInteract;

            public static void ShowInteraction(string message)
            {
                if (OnShowInteraction == null)
                    return;

                OnShowInteraction(message);
            }

            public static void HideInteraction()
            {
                if (OnHideInteraction == null)
                    return;

                OnHideInteraction();
            }

            public static void Interact()
            {
                if (OnInteract == null)
                    return;

                OnInteract();
            }
        }
    
        public struct DialogEvents
        {
            public static event Action<Dialog> OnStartDialog;

            public static void StartDialog(Dialog dialog)
            {
                if (OnStartDialog == null)
                    return;

                OnStartDialog(dialog);
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
                if(OnHideAll == null)
                    return;

                OnHideAll();
            }

            public static void UnhideAll()
            {
                if(OnUnhideAll == null)
                    return;

                OnUnhideAll();
            }
        }
    }
}
