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


    public void Trigger(Puzzle1_Child child)
    {
        child.IsTriggered = true;
        child.GetComponent<MeshRenderer>().material = triggeredMaterial;
        if (puzzlePieces.TrueForAll(x => x.IsTriggered))
        {
            CompletePuzzle();
        }
    }

    public void CompletePuzzle()
    {
        GetComponent<MeshRenderer>().material = triggeredMaterial;
        GetComponent<Animator>().SetTrigger("Complete");
        Destroy(puzzle1_Trigger);
    }
}
