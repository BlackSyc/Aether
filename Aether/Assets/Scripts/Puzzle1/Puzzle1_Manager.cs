using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Manager : MonoBehaviour
{
    public struct Events
    {
        public static event Action OnStage1Completed;
        public static event Action OnStage2Completed;

        public static void Stage2Completed()
        {
            OnStage2Completed?.Invoke();
        }

        public static void Stage1Completed()
        {
            OnStage1Completed?.Invoke();
        }
    }

    [SerializeField]
    private List<Puzzle1_PressurePlate> pressurePlates;

    [SerializeField]
    private List<Puzzle1_MissileTarget> missileTargets;


    private void Start()
    {
        Puzzle1_PressurePlate.Events.OnTriggered += CheckForStage1Completion;
        Puzzle1_MissileTarget.Events.OnMissileTargetHit += CheckForStage2Completion;
    }

    private void CheckForStage1Completion()
    {
        if (pressurePlates.TrueForAll(x => x.IsTriggered))
             Events.Stage1Completed();
    }

    private void CheckForStage2Completion()
    {
        if (missileTargets.TrueForAll(x => x.IsHit))
            Events.Stage2Completed();
    }

    private void OnDestroy()
    {
        Puzzle1_PressurePlate.Events.OnTriggered -= CheckForStage1Completion;
        Puzzle1_MissileTarget.Events.OnMissileTargetHit -= CheckForStage2Completion;
    }
}
