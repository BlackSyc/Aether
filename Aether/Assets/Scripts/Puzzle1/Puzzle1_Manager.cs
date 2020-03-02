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
    private List<Puzzle1_Child> puzzlePieces;

    [SerializeField]
    private GameObject aspectOfCreation;


    private Material defaultMaterial;

    public void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    public void Trigger(Puzzle1_Child child)
    {
        child.IsTriggered = true;
        child.GetComponent<MeshRenderer>().material = triggeredMaterial;
        if (puzzlePieces.TrueForAll(x => x.IsTriggered))
        {
            CompleteStage1();
        }
    }

    public void CompleteStage1()
    {
        GetComponent<MeshRenderer>().material = triggeredMaterial;
        GetComponent<Animator>().SetTrigger("Stage1_Complete");
        Destroy(puzzle1_Trigger);
        aspectOfCreation.SetActive(true);
    }

    public void StartStage2()
    {
        Destroy(aspectOfCreation);
        Debug.Log("Started stage 2!");
        GetComponent<MeshRenderer>().material = defaultMaterial;
        GetComponent<Animator>().SetTrigger("Stage2_Start");
    }
}
