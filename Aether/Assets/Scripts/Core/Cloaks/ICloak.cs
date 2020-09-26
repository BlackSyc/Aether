using Syc.Combat.SpellSystem.ScriptableObjects;
using UnityEngine;

namespace Aether.Core.Cloaks
{
    public interface ICloak
    {
        string Name { get; }

        Aspect Aspect { get; }

        Color Colour { get; }

        string Keywords { get; }

        string Description { get; }

        Spell[] Spells { get; }

        GameObject CloakPrefab { get; }
    }
}
