using Aether.Core;
using Aether.Core.SceneManagement;
using System.Collections;
using Syc.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneAsset = UnityEngine.Object;

namespace Aether.Attunement
{
    public class Traveller : MonoBehaviour, ILocalPlayerLink
    {
        [HideInInspector]
        public AnimationClip TravelAnimation;

        private Animator animator;

        [HideInInspector]
        public int SceneBuildIndex;

        private AsyncOperation levelLoadingOperation;

        private bool levelIsLoaded => SceneController.Instance.IsLevelLoaded(SceneBuildIndex);

        private Player _player;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            SceneController.Events.OnLevelStartedLoading += LevelStartedLoading;
            Player.LinkToLocalPlayer(this);
        }

        private void LevelStartedLoading(int buildIndex, AsyncOperation asyncOperation)
        {
            if (buildIndex != this.SceneBuildIndex)
                return;

            levelLoadingOperation = asyncOperation;
        }

        public void StartTravel(bool reverse)
        {
            // if the level is already loaded (or reverse is true), just play the (possibly reversed) animation in default time;
            if (levelIsLoaded || reverse)
            {
                StartCoroutine(TravelDefault(reverse, _player));
                return;
            }

            levelLoadingOperation = null;
            SceneController.Instance.LoadLevel(SceneBuildIndex);

            StartCoroutine(TravelUsingLoadingProgress(_player));
        }

        private IEnumerator TravelDefault(bool reverse, Player player)
        {
            player.gameObject.transform.parent = gameObject.transform;
            player.gameObject.transform.localPosition = Vector3.zero;

            if (player.Has(out MovementSystem movementSystem))
                movementSystem.IsActive = false;

            animator.Play(reverse ? $"{TravelAnimation.name}Reverse" : TravelAnimation.name);
            yield return new WaitForSeconds(TravelAnimation.length);

            player.gameObject.transform.SetParent(null, true);
            SceneManager.MoveGameObjectToScene(player.gameObject, SceneController.Instance.BaseScene);
            
            if(movementSystem != default)
                movementSystem.IsActive = true;
        }

        private IEnumerator TravelUsingLoadingProgress(Player player)
        {
            player.gameObject.transform.parent = gameObject.transform;
            player.gameObject.transform.localPosition = Vector3.zero;
            
            if (player.Has(out MovementSystem movementSystem))
                movementSystem.IsActive = false;

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

            player.gameObject.transform.SetParent(null, true);
            SceneManager.MoveGameObjectToScene(player.gameObject, SceneController.Instance.BaseScene);
            
            if(movementSystem != default)
                movementSystem.IsActive = true;
        }

        public void OnLocalPlayerLinked(Player player)
        {
            _player = player;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _player = null;
        }
    }
}
