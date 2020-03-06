using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherEvents : MonoBehaviour
{

    public struct GameEvents
    {
        public struct Interaction 
        {
            public static event Action<string> ShowInteraction;
            public static event Action HideInteraction;
            public static event Action Interact;

            public static void InvokeShowInteraction(string message)
            {
                if (ShowInteraction == null)
                    return;

                ShowInteraction(message);
            }

            public static void InvokeHideInteraction()
            {
                if (HideInteraction == null)
                    return;

                HideInteraction();
            }

            public static void InvokeInteract()
            {
                if (Interact == null)
                    return;

                Interact();
            }
        }
    
    }

    public struct UIEvents
    {
        public struct ToolTips
        {
            public static event Action HideAll;
            public static event Action UnhideAll;

            public static void InvokeHideAll()
            {
                if(HideAll == null)
                    return;

                HideAll();
            }

            public static void InvokeUnhideAll()
            {
                if(UnhideAll == null)
                    return;

                UnhideAll();
            }
        }
    }
}
