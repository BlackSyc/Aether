using System;
using UnityEngine;


namespace Aether.SpellSystem.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spell System/Spell")]
    [Serializable]
    public class Spell : ScriptableObject
    {
        public string Name;

        public Aspect Aspect;

        [TextArea(0, 10)]
        public string Description;

        public float Damage;

        public float Heal;

        public int GlobalAggro;

        public int LocalAggro;

        public float CastDuration;

        public float CoolDown;

        public bool CastWhileMoving;

        public LayerMask LayerMask;

        public SpellObject SpellObject;

    }
}
