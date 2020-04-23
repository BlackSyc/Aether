using System;
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
    }

    public struct UIEvents
    {   
        public struct Windows
        {
            public static event Action OnClosePopups;

            public static void ClosePopups()
            {
                OnClosePopups?.Invoke();
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
