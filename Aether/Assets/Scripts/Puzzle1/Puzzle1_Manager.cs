using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Manager : MonoBehaviour
{
    [SerializeField]
    private List<Puzzle1_Child> puzzlePieces;

    [SerializeField]
    private Material puzzleCompleteMaterial;

    public void CheckPuzzleComplete()
    {
        if(puzzlePieces.TrueForAll(x => x.IsTriggered))
        {
            GetComponent<MeshRenderer>().material = puzzleCompleteMaterial;
            Debug.Log("Puzzle1 completed!");
        }
    }
}
