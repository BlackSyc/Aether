using System.Collections.Generic;
using UnityEngine;


namespace Aether.Core.Items.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Items/Keystone")]
    public class Keystone : ScriptableObject
    {
        public string Name;

        public Aspect Aspect;

        public List<string> Labels;

        [TextArea]
        public string Description;

        public Sprite Sprite;

        public bool KeystoneCompleted;

        public AnimationClip TravelAnimation;

        public int SceneBuildIndex;

        private KeystoneState state = new KeystoneState();

        private struct KeystoneState
        {
            public bool IsActivated;

            public bool IsFound;
        }

        public bool IsActivated => state.IsActivated;

        public bool IsFound => state.IsFound;

        public void Found()
        {
            state.IsFound = true;
        }

        public void Activate()
        {
            state.IsActivated = true;
            AetherEvents.KeystoneEvents.KeystoneActivated(this);
        }

        public void Deactivate()
        {
            state.IsActivated = false;
            AetherEvents.KeystoneEvents.KeystoneDeactivated(this);
        }
    }
}
