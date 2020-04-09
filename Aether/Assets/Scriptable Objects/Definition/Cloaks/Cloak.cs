using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cloaks/Cloak")]
public class Cloak : ScriptableObject
{
    public struct Events 
    {
        public static event Action<Cloak> OnCloakEquipped;
        public static event Action<Cloak> OnCloakUnequipped;

        public static void CloakUnequipped(Cloak cloakInfo)
        {
            OnCloakUnequipped?.Invoke(cloakInfo);
        }

        public static void CloakEquipped(Cloak cloakInfo)
        {
            OnCloakEquipped?.Invoke(cloakInfo);
        }
    }

    public string Name;
    public Aspect Aspect;
    public Color Colour;
    public string Keywords;

    [TextArea]
    public string Description;

    public Spell[] Spells;

    [SerializeField]
    private GameObject cloakPrefab;

    public struct CloakInfoState
    {
        public GameObject CloakObject;
    }

    private CloakInfoState State = new CloakInfoState();

    public void Equip(Transform parent)
    {
        State.CloakObject = GameObject.Instantiate(cloakPrefab, parent);
        State.CloakObject.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { parent.GetComponent<CapsuleCollider>() };

        for(int i = 0; i < Player.Instance.SpellSystem.SpellLibraries.Length; i++)
        {
            if (i >= Spells.Length)
                break;

            Player.Instance.SpellSystem.SpellLibraries[i].SetActiveSpell(Spells[i]);

        }

        Events.CloakEquipped(this);
    }

    public bool IsEquipped { get
        {
            return State.CloakObject;
        } }

    public void Unequip()
    {
        Destroy(State.CloakObject);
        State.CloakObject = null;

        Events.CloakUnequipped(this);
    }
}
