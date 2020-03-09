using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectPlatform : MonoBehaviour
{

    [SerializeField]
    private Material glowingMaterial;

    private Material defaultMaterial;

    void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;

        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 += ChangeToGlowingMaterial;
        AetherEvents.GameEvents.Puzzle1Events.OnAspectOfCreationDialogComplete += ChangeToDefaultMaterial;
    }

    private void ChangeToGlowingMaterial()
    {
        GetComponent<MeshRenderer>().material = glowingMaterial;
    }

    private void ChangeToDefaultMaterial()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnCompleteStage1 -= ChangeToGlowingMaterial;
        AetherEvents.GameEvents.Puzzle1Events.OnAspectOfCreationDialogComplete -= ChangeToDefaultMaterial;
    }
}
