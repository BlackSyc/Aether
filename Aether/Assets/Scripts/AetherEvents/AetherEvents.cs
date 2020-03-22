using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class AetherEvents
{

    public struct GameEvents
    {
        public struct HubEvents 
        {

            public static event Action OnTravelToAccessPoint;

            public static void TravelToAccessPoint()
            {
                OnTravelToAccessPoint?.Invoke();
            }
        }
        
        public struct InputSystemEvents
        {
            public static event Action OnEnablePopupActionMap;

            public static event Action OnEnablePlayerActionMap;
            
            public static void EnablePopupActionMap()
            {
                OnEnablePopupActionMap?.Invoke();
            }

            public static void EnablePlayerActionMap()
            {
                OnEnablePlayerActionMap?.Invoke();
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
   
        public struct Windows
        {
            public static event Action OnClosePopups;

            public static void ClosePopups()
            {
                OnClosePopups?.Invoke();
            }
        }

        public struct Crosshair
        {
            public static event Action OnHideCrosshair;
            public static event Action OnUnhideCrosshair;

            public static void HideCrosshair()
            {
                OnHideCrosshair?.Invoke();
            }

            public static void UnhideCrosshair()
            {
                OnUnhideCrosshair?.Invoke();
            }
        }
    }

    public struct CameraEvents
    {
        public static event Action<Camera> OnEnableCutsceneCamera;

        public static event Action OnEnablePlayercamera;

        public static void EnableCutsceneCamera(Camera camera)
        {
            OnEnableCutsceneCamera?.Invoke(camera);
        }

        public static void EnablePlayerCamera()
        {
            OnEnablePlayercamera?.Invoke();
        }
    }
}
