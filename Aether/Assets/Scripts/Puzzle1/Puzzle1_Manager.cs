using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle1_Trigger;

    [SerializeField]
    private Material glowingMaterial;

    public Material GlowingMaterial
    {
        get
        {
            return glowingMaterial;
        }
    }

    [SerializeField]
    private List<Puzzle1_PressurePlate> pressurePlates;

    [SerializeField]
    private List<ArcaneMissileTarget> missileTargets;

    [SerializeField]
    private GameObject cloakParent;


    [SerializeField]
    private GameObject aspectOfCreation;

    private Material defaultMaterial;

    public bool Stage1Complete { get; private set; }

    public bool Stage2Complete { get; private set; }

    public void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    public bool TryCompleteStage1()
    {
        if (pressurePlates.TrueForAll(x => x.IsTriggered))
        {
            CompleteStage1();
            return true;
        }
        return false;
    }

    public bool TryCompleteStage2()
    {
        if (missileTargets.TrueForAll(x => x.IsHit))
        {
            CompleteStage2();
            return true;
        }
        return false;

    }

    private void CompleteStage2()
    {
        Debug.Log("Completed Stage 2!");
        Stage2Complete = true;
        //cloakParent.SetActive(true);
        missileTargets.ForEach(x => x.MoveToCloakPosition());
    }

    private void CompleteStage1()
    {
        GetComponent<MeshRenderer>().material = GlowingMaterial;
        missileTargets.ForEach(x => x.MoveToCenter());
        Destroy(puzzle1_Trigger);
        aspectOfCreation.SetActive(true);
        Stage1Complete = true;
    }

    public void StartStage2()
    {
        Destroy(aspectOfCreation);
        GetComponent<MeshRenderer>().material = defaultMaterial;
        missileTargets.ForEach(x => x.MoveToOriginalPosition());
    }
}
