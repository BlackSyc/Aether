﻿using Aether.Core.Cloaks;
using Aether.Core.Combat;
using Aether.ScriptableObjects.Spells;
using UnityEngine;


namespace Aether.ScriptableObjects.Cloaks
{

    [CreateAssetMenu(menuName = "Scriptable Objects/Cloaks/Cloak")]
    public class Cloak : ScriptableObject, ICloak
    {
        [SerializeField]
        private string name;

        public string Name => name;

        [SerializeField]
        private Aspect aspect;

        public Aspect Aspect => aspect;

        [SerializeField]
        private Color colour;

        public Color Colour { get; }

        [SerializeField]
        private string keywords;

        public string Keywords => keywords;

        [TextArea]
        [SerializeField]
        private string description;

        public string Description => description;

        [SerializeField]
        private SpellBase[] spells;

        public ISpell[] Spells => spells;

        [SerializeField]
        private GameObject cloakPrefab;

        public GameObject CloakPrefab => cloakPrefab;

    }
}
