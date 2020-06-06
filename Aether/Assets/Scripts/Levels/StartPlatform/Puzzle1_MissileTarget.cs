using Aether.Core.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace Aether.StartPlatform
{
    public class Puzzle1_MissileTarget : MonoBehaviour, ITarget
    {
        public struct Events
        {
            public static event Action OnMissileTargetHit;

            public static void MissileTargetHit()
            {
                OnMissileTargetHit?.Invoke();
            }
        }

        [SerializeField]
        private GameObject cloakProvider;

        [SerializeField]
        private float resetAfter = 5;

        public bool IsHit { get; private set; }


        private void StopResetTimerAndMoveToCloakPosition()
        {
            GetComponent<Animator>().SetTrigger("MoveToCloakPosition");
            StopAllCoroutines();

            if (cloakProvider != null)
                StartCoroutine(ExecuteAfter(5, () => cloakProvider.SetActive(true)));
        }

        private void MoveToCenter()
        {
            GetComponent<Animator>().SetTrigger("MoveToCenter");
        }

        private void MoveToOriginalPosition()
        {
            GetComponent<Animator>().SetTrigger("MoveToOriginalPosition");
        }

        private void Start()
        {
            Puzzle1_Manager.Events.OnStage1Completed += MoveToCenter;
            AspectOfCreation.Events.OnDialogComplete += MoveToOriginalPosition;
            Puzzle1_Manager.Events.OnStage2Completed += StopResetTimerAndMoveToCloakPosition;
        }

        public void Hit()
        {
            if (IsHit)
                return;

            GetComponent<Animator>().SetBool("Hit", true);
            IsHit = true;
            gameObject.layer = LayerMask.NameToLayer("Obstruction");
            StopAllCoroutines();

            Events.MissileTargetHit();

            StartCoroutine(ResetTimer(resetAfter));
        }

        private IEnumerator ExecuteAfter(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);

            action.Invoke();

        }

        private IEnumerator ResetTimer(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            IsHit = false;
            gameObject.layer = LayerMask.NameToLayer("Target");
            GetComponent<Animator>().SetBool("Hit", false);
        }

        private void OnDestroy()
        {
            Puzzle1_Manager.Events.OnStage1Completed -= MoveToCenter;
            AspectOfCreation.Events.OnDialogComplete -= MoveToOriginalPosition;
            Puzzle1_Manager.Events.OnStage2Completed -= StopResetTimerAndMoveToCloakPosition;
        }
    }
}
