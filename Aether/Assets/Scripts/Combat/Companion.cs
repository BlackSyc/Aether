using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Companion;
using System;
using UnityEngine;

namespace Aether.Combat
{
    public class Companion : MonoBehaviour, ICompanion
    {
        public struct Events
        {
            public static event Action<Companion> OnCompanionAdded;

            public static event Action OnCompanionRemoved;

            public static void CompanionAdded(Companion companion)
            {
                OnCompanionAdded?.Invoke(companion);
            }

            public static void CompanionRemoved()
            {
                OnCompanionRemoved?.Invoke();
            }
        }
        private ICloak equippedCloak;

        private void Start()
        {
            equippedCloak = Player.Instance.Get<IShoulder>().EquippedCloak;
            //Player.Instance.Companion = this; I don't want a setter on exposed objects
            Events.CompanionAdded(this);
            Aether.Core.Cloaks.Events.OnCloakUnequipped += CloakUnequipped;
        }

        private void CloakUnequipped(ICloak cloak)
        {
            if (cloak == equippedCloak)
            {
                //Player.Instance.Companion = null;
                Destroy(gameObject);
                Events.CompanionRemoved();
            }
        }

        private void OnDestroy()
        {
            Core.Cloaks.Events.OnCloakUnequipped -= CloakUnequipped;
        }
    }
}