using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessPoint : MonoBehaviour
{
    public Keystone Keystone;

    [SerializeField]
    private Scene scene;

    [SerializeField]
    private KeystoneTraveller traveller;

    [SerializeField]
    private float minimumTravelTime = 5f;

    [SerializeField]
    private Transform destination;

    [SerializeField]
    private Transform origin;

    private void Start()
    {
        AetherEvents.GameEvents.HubEvents.OnTravelToAccessPoint += StartTravel;
    }

    private void StartTravel()
    {
        AetherEvents.GameEvents.PlayerEvents.ActivateInteractor(false);
        AetherEvents.GameEvents.PlayerEvents.ShowModel(false);
        AetherEvents.CameraEvents.EnableCutsceneCamera(traveller.Camera);

        //AsyncOperation loadSceneOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
        AsyncOperation loadSceneOperation = null;
        StartCoroutine(Travel(loadSceneOperation));
    }

    public void StartTravelBack()
    {
        AetherEvents.GameEvents.PlayerEvents.ActivateInteractor(false);
        AetherEvents.GameEvents.PlayerEvents.ShowModel(false);
        AetherEvents.CameraEvents.EnableCutsceneCamera(traveller.Camera);
        //AsyncOperation unloadSceneOperation = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
        AsyncOperation unloadSceneOperation = null;
        StartCoroutine(TravelBack(unloadSceneOperation));
    }

    private IEnumerator TravelBack(AsyncOperation unloadSceneOperation)
    {
        float startTime = Time.time;
        float minimumEndTime = startTime + minimumTravelTime;

        while (minimumEndTime > Time.time)
        {
            float maximumProgress = (Time.time - startTime) / minimumTravelTime;
            traveller.TravelBack(maximumProgress);
            yield return null;
        }

        traveller.TravelBack(1);
        AetherEvents.GameEvents.PlayerEvents.SetPlayerPosition(origin.position);
        AetherEvents.GameEvents.PlayerEvents.ShowModel(true);
        AetherEvents.GameEvents.PlayerEvents.ActivateInteractor(true);
        AetherEvents.CameraEvents.EnablePlayerCamera();
    }

    private IEnumerator Travel(AsyncOperation loadSceneOperation)
    {
        float startTime = Time.time;
        float minimumEndTime = startTime + minimumTravelTime;

        while(minimumEndTime > Time.time)
        {
            float maximumProgress = (Time.time - startTime) / minimumTravelTime;
            traveller.Travel(maximumProgress);
            yield return null;
        }

        traveller.Travel(1);
        AetherEvents.GameEvents.PlayerEvents.SetPlayerPosition(destination.position);
        AetherEvents.GameEvents.PlayerEvents.ShowModel(true);
        AetherEvents.GameEvents.PlayerEvents.ActivateInteractor(true);
        AetherEvents.CameraEvents.EnablePlayerCamera();
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.HubEvents.OnTravelToAccessPoint -= StartTravel;
    }

}
