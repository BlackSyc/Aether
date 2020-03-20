using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    private Camera activeCamera;

    // Start is called before the first frame update
    void Start()
    {
        activeCamera = playerCamera;
        AetherEvents.CameraEvents.OnEnableCutsceneCamera += EnableCutsceneCamera;
        AetherEvents.CameraEvents.OnEnablePlayercamera += EnablePlayerCamera;
    }

    private void EnablePlayerCamera()
    {
        activeCamera.enabled = false;
        activeCamera = playerCamera;
        activeCamera.enabled = true;
    }

    private void EnableCutsceneCamera(Camera cutsceneCamera)
    {
        activeCamera.enabled = false;
        activeCamera = cutsceneCamera;
        activeCamera.enabled = true;
    }

    private void OnDestroy()
    {
        AetherEvents.CameraEvents.OnEnableCutsceneCamera -= EnableCutsceneCamera;
        AetherEvents.CameraEvents.OnEnablePlayercamera -= EnablePlayerCamera;
    }
}


