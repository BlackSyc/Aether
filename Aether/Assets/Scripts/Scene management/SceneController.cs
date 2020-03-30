using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneAsset = UnityEngine.Object;

public class SceneController : MonoBehaviour
{
    public struct Events
    {
        public static event Action<int, AsyncOperation> OnLevelStartedLoading;

        public static event Action<int, AsyncOperation> OnLevelStartedUnloading;

        public static void LevelStartedLoading(int buildIndex, AsyncOperation asyncOperation)
        {
            OnLevelStartedLoading?.Invoke(buildIndex, asyncOperation);
        }

        public static void LevelStartedUnloading(int buildIndex, AsyncOperation asyncOperation)
        {
            OnLevelStartedUnloading?.Invoke(buildIndex, asyncOperation);
        }
    }
    public static SceneController Instance { get; private set; }

    public Scene BaseScene { get; private set; }

    [SerializeField]
    private int startPlatformSceneBuildIndex;

    [HideInInspector]
    public StartPlatformController StartPlatformLevelController;

    public (int? buildIndex, ILevelController levelController) LoadedLevel;

    private AsyncOperation loadLevelOperation;

    private AsyncOperation unloadLevelOperation;

    // Returns whether the scene was already loaded or not.
    public void LoadLevel(int buildIndex)
    {
        // Check if the currently loaded level is the same as the one requested, in that case: throw an exception.
        if (LoadedLevel.buildIndex == buildIndex)
            throw new Exception($"Level {buildIndex} is already loaded.");

        // Check if a level is currently being loaded, in that case: wait for it to complete, then request LoadLevel again.
        if (loadLevelOperation != null && !loadLevelOperation.isDone)
        {
            Debug.Log("A level is currently being loaded!");
            loadLevelOperation.completed += _ => LoadLevel(buildIndex);
            return;
        }

        // Check if there is a level currently loaded (not equal to the one requested, see above), in that case: Unload the current level, and when that is complete, request LoadLevel again.
        if(LoadedLevel.buildIndex != null)
        {
            UnloadCurrentLevel();
            unloadLevelOperation.completed += _ => LoadLevel(buildIndex);
            return;
        }

        // Load the requested level, on complete set the loaded level field.
        loadLevelOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Events.LevelStartedLoading(buildIndex, loadLevelOperation);
        loadLevelOperation.completed += _ => LoadedLevel.buildIndex = buildIndex;
    }

    // returns whether the provided scene asset is currently loaded.
    public bool IsLevelLoaded(int buildIndex)
    {
        return LoadedLevel.buildIndex == buildIndex;
    }

    public void UnloadLevel(int buildIndex)
    {
        if(LoadedLevel.buildIndex == buildIndex)
        {
            LoadedLevel.buildIndex = null;
            LoadedLevel.levelController = null;
            Events.LevelStartedUnloading(buildIndex, SceneManager.UnloadSceneAsync(buildIndex));
        }
    }

    private void UnloadCurrentLevel()
    {
        if (LoadedLevel.buildIndex == null)
            return;

        unloadLevelOperation = SceneManager.UnloadSceneAsync(LoadedLevel.buildIndex.Value);
        Events.LevelStartedUnloading(LoadedLevel.buildIndex.Value, unloadLevelOperation);
        unloadLevelOperation.completed += _ => LoadedLevel.buildIndex = null;
    }

    private void Awake()
    {
        if (Instance)
            throw new Exception("There is more than one SceneController object in the game!");

        Instance = this;
        Debug.Log($"startingplatformscene name: {startPlatformSceneBuildIndex}");
        BaseScene = gameObject.scene;

        if (SceneManager.GetSceneAt(1).buildIndex == startPlatformSceneBuildIndex)
            return;

        SceneManager.LoadScene(startPlatformSceneBuildIndex, LoadSceneMode.Additive);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
