using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneAsset = UnityEngine.Object;

public class Traveller : MonoBehaviour
{
    public AnimationClip TravelAnimation;

    private Animator animator;

    public SceneAsset SceneAsset;

    private AsyncOperation levelLoadingOperation;

    private bool levelIsLoaded => SceneController.Instance.IsLevelLoaded(SceneAsset);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SceneController.Events.OnLevelStartedLoading += LevelStartedLoading;
    }

    private void LevelStartedLoading(SceneAsset sceneAsset, AsyncOperation asyncOperation)
    {
        if (sceneAsset != this.SceneAsset)
            return;

        levelLoadingOperation = asyncOperation;
    }

    public void StartTravel(bool reverse)
    {
        // if the level is already loaded (or reverse is true), just play the (possibly reversed) animation in default time;
        if (levelIsLoaded || reverse)
        {
            StartCoroutine(TravelDefault(reverse));
            return;
        }

        levelLoadingOperation = null;
        SceneController.Instance.LoadLevel(SceneAsset);

        StartCoroutine(TravelUsingLoadingProgress());
    }

    private IEnumerator TravelDefault(bool reverse)
    {
        Debug.Log("Start travel (scene was already loaded)");
        Player.Instance.gameObject.transform.parent = gameObject.transform;
        Player.Instance.PlayerMovement.enabled = false;

        float startTime = Time.time;
        float maximumAnimationProgress = 0;
        while (maximumAnimationProgress < 1)
        {
            maximumAnimationProgress = (Time.time - startTime) / TravelAnimation.length;
            animator.Play(reverse ? $"{TravelAnimation.name}Reverse" : TravelAnimation.name, -1, maximumAnimationProgress);
            yield return null;
        }

        Player.Instance.gameObject.transform.parent = null;
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneController.Instance.BaseScene);
        Player.Instance.PlayerMovement.enabled = true;
        Debug.Log("End travel");
    }

    private IEnumerator TravelUsingLoadingProgress()
    {
        Debug.Log("Start travel and load scene");
        Player.Instance.gameObject.transform.parent = gameObject.transform;
        Player.Instance.PlayerMovement.enabled = false;

        while (levelLoadingOperation == null)
        {
            Debug.Log("Waiting for level to start loading");
            yield return null;
        }

        float startTime = Time.time;
        float maximumAnimationProgress = 0;
        while (!levelLoadingOperation.isDone || maximumAnimationProgress < 1)
        {
            maximumAnimationProgress = (Time.time - startTime) / TravelAnimation.length;
            animator.Play(TravelAnimation.name, -1, maximumAnimationProgress < levelLoadingOperation.progress ? maximumAnimationProgress : levelLoadingOperation.progress);
            yield return null;
        }

        animator.Play(TravelAnimation.name, -1, 1f);

        Player.Instance.gameObject.transform.parent = null;
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneController.Instance.BaseScene);
        Player.Instance.PlayerMovement.enabled = true;
        Debug.Log("End travel");
    }
}
