using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Manager : MonoBehaviour
{

    [SerializeField]
    private List<Puzzle1_PressurePlate> pressurePlates;

    [SerializeField]
    private List<ArcaneMissileTarget> missileTargets;


    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnPressurePlateTriggered += CheckForStage1Completion;
        AetherEvents.GameEvents.Puzzle1Events.OnMissileTargetHit += CheckForStage2Completion;
    }

    private void CheckForStage1Completion()
    {
        if (pressurePlates.TrueForAll(x => x.IsTriggered))
             AetherEvents.GameEvents.Puzzle1Events.CompleteStage1();
    }

    private void CheckForStage2Completion()
    {
        if (missileTargets.TrueForAll(x => x.IsHit))
            AetherEvents.GameEvents.Puzzle1Events.CompleteStage2();
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnPressurePlateTriggered -= CheckForStage1Completion;
        AetherEvents.GameEvents.Puzzle1Events.OnMissileTargetHit -= CheckForStage2Completion;
    }
}
