using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cloaks/CloakInfo")]
public class CloakInfo : ScriptableObject
{
    public string Name;
    public Aspect Aspect;
    public Color Colour;
    public string Keywords;

    [TextArea]
    public string Description;

    [SerializeField]
    private GameObject cloakPrefab;

    public struct CloakInfoState
    {
        public bool Equipped;
    }

    private CloakInfoState State = new CloakInfoState();

    public Cloak InstantiateCloak(Transform parent)
    {
        GameObject cloakObject = GameObject.Instantiate(cloakPrefab, parent);
        return cloakObject.GetComponent<Cloak>();
    }

    public bool IsEquipped { get
        {
            return State.Equipped;
        } }

    public void Equip()
    {
        State.Equipped = true;
        AetherEvents.GameEvents.CloakEvents.CloakEquipped(this);
    }

    public void UnEquip()
    {
        State.Equipped = false;
        AetherEvents.GameEvents.CloakEvents.CloakUnequipped(this);
    }

    public void Show()
    {
        AetherEvents.GameEvents.CloakEvents.ShowCloakInfo(this);
    }
}
