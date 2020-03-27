using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneAsset = UnityEngine.Object;

public class SceneController : MonoBehaviour
{
    public struct Events
    {
        public static event Action<SceneAsset, AsyncOperation> OnLevelStartedLoading;

        public static event Action<SceneAsset, AsyncOperation> OnLevelStartedUnloading;

        public static void LevelStartedLoading(SceneAsset sceneAsset, AsyncOperation asyncOperation)
        {
            OnLevelStartedLoading?.Invoke(sceneAsset, asyncOperation);
        }

        public static void LevelStartedUnloading(SceneAsset sceneAsset, AsyncOperation asyncOperation)
        {
            OnLevelStartedUnloading?.Invoke(sceneAsset, asyncOperation);
        }
    }
    public static SceneController Instance { get; private set; }

    public Scene BaseScene { get; private set; }

    [SerializeField]
    private SceneAsset startPlatformScene;

    private SceneAsset loadedLevel;

    private AsyncOperation loadLevelOperation;

    private AsyncOperation unloadLevelOperation;

    // Returns whether the scene was already loaded or not.
    public void LoadLevel(SceneAsset sceneAsset)
    {
        // Check if the currently loaded level is the same as the one requested, in that case: throw an exception.
        if (loadedLevel == sceneAsset)
            throw new Exception($"Level {sceneAsset.name} is already loaded.");

        // Check if a level is currently being loaded, in that case: wait for it to complete, then request LoadLevel again.
        if (loadLevelOperation != null && !loadLevelOperation.isDone)
        {
            Debug.Log("A level is currently being loaded!");
            loadLevelOperation.completed += _ => LoadLevel(sceneAsset);
            return;
        }

        // Check if there is a level currently loaded (not equal to the one requested, see above), in that case: Unload the current level, and when that is complete, request LoadLevel again.
        if(loadedLevel != null)
        {
            UnloadCurrentLevel();
            unloadLevelOperation.completed += _ => LoadLevel(sceneAsset);
            return;
        }

        // Load the requested level, on complete set the loaded level field.
        loadLevelOperation = SceneManager.LoadSceneAsync(sceneAsset.name, LoadSceneMode.Additive);
        Events.LevelStartedLoading(sceneAsset, loadLevelOperation);
        loadLevelOperation.completed += _ => loadedLevel = sceneAsset;
    }

    // returns whether the provided scene asset is currently loaded.
    public bool IsLevelLoaded(SceneAsset sceneAsset)
    {
        return loadedLevel == sceneAsset;
    }

    public void UnloadLevel(SceneAsset sceneAsset)
    {
        if(loadedLevel == sceneAsset)
        {
            loadedLevel = null;
            Events.LevelStartedUnloading(sceneAsset, SceneManager.UnloadSceneAsync(sceneAsset.name));
        }
    }

    private void UnloadCurrentLevel()
    {
        unloadLevelOperation = SceneManager.UnloadSceneAsync(loadedLevel.name);
        Events.LevelStartedUnloading(loadedLevel, unloadLevelOperation);
        unloadLevelOperation.completed += _ => loadedLevel = null;
    }

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one SceneController object in the game!");

        Instance = this;
        BaseScene = gameObject.scene;

        // Checks if the starting scene was already loaded. If not: load it.
        if (!SceneManager.GetSceneByName(startPlatformScene.name).IsValid())
        {
            SceneManager.LoadScene(startPlatformScene.name, LoadSceneMode.Additive);
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
