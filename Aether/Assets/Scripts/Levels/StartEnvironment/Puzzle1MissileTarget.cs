using System;
using System.Collections;
using Syc.Combat;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    [RequireComponent(typeof(ICombatSystem))]
    public class Puzzle1MissileTarget : MonoBehaviour, ICombatSubSystem
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
        public ICombatSystem System { get; set; }

        [SerializeField]
        private float resetAfter = 5;

        public bool IsHit { get; private set; }

        #region MonoBehaviour
        
        private void Awake()
        {
            System = GetComponent<ICombatSystem>();
            System.AddSubsystem(this);
        }
        
        private void Start()
        {
            Puzzle1_Manager.Events.OnStage1Completed += MoveToCenter;
            AspectOfCreation.Events.OnDialogComplete += MoveToOriginalPosition;
            Puzzle1_Manager.Events.OnStage2Completed += StopResetTimerAndMoveToCloakPosition;
        }
        
        private void OnDestroy()
        {
            Puzzle1_Manager.Events.OnStage1Completed -= MoveToCenter;
            AspectOfCreation.Events.OnDialogComplete -= MoveToOriginalPosition;
            Puzzle1_Manager.Events.OnStage2Completed -= StopResetTimerAndMoveToCloakPosition;
            System.RemoveSubsystem(this);
            System = default;
        }
        
        #endregion


        private void StopResetTimerAndMoveToCloakPosition()
        {
            System.CanBeTargeted = false;
            GetComponent<Animator>().SetTrigger("MoveToCloakPosition");
            StopAllCoroutines();

            if (cloakProvider != null)
                StartCoroutine(ExecuteAfter(3, () => cloakProvider.SetActive(true)));
        }

        private void MoveToCenter()
        {
            GetComponent<Animator>().SetTrigger("MoveToCenter");
        }

        private void MoveToOriginalPosition()
        {
            GetComponent<Animator>().SetTrigger("MoveToOriginalPosition");
            System.CanBeTargeted = true;
        }

        public void Hit()
        {
            if (IsHit)
                return;

            GetComponent<Animator>().SetBool("Hit", true);
            IsHit = true;
            gameObject.layer = LayerMask.NameToLayer("Obstruction");
            System.CanBeTargeted = false;
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
            System.CanBeTargeted = true;
        }

        public void Tick(float deltaTime)
        {
        }
    }
}
