using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cloaks/CloakInfo")]
public class CloakInfo : ScriptableObject
{
    public string Name;
    public Color Colour;
    public string Keywords;

    [TextArea]
    public string Description;

    public GameObject CloakPrefab;

    public void Show()
    {
        AetherEvents.GameEvents.CloakEvents.ShowCloakInfo(this);
    }
}
