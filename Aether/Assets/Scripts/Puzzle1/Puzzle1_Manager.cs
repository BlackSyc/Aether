using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle1_Trigger;

    [SerializeField]
    private Material triggeredMaterial;

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

    public void Trigger(Puzzle1_PressurePlate pressurePlate)
    {
        pressurePlate.IsTriggered = true;
        pressurePlate.GetComponent<MeshRenderer>().material = triggeredMaterial;
        if (pressurePlates.TrueForAll(x => x.IsTriggered))
        {
            CompleteStage1();
        }
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
        cloakParent.SetActive(true);
        missileTargets.ForEach(x => Destroy(x, 5));
    }

    private void CompleteStage1()
    {
        GetComponent<MeshRenderer>().material = triggeredMaterial;
        GetComponent<Animator>().SetTrigger("Stage1_Complete");
        Destroy(puzzle1_Trigger);
        aspectOfCreation.SetActive(true);
        Stage1Complete = true;
    }

    public void StartStage2()
    {
        Destroy(aspectOfCreation);
        GetComponent<MeshRenderer>().material = defaultMaterial;
        GetComponent<Animator>().SetTrigger("Stage2_Start");
    }
}
