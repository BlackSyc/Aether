using Aether.Core.Combat;
using UnityEngine;


namespace Aether.Core.Cloaks.ScriptableObjects 
{ 

    [CreateAssetMenu(menuName = "Scriptable Objects/Cloaks/Cloak")]
    public class Cloak : ScriptableObject
    {

        public string Name;
        public Aspect Aspect;
        public Color Colour;
        public string Keywords;

        [TextArea]
        public string Description;

        public ISpell[] Spells;

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

            if (Spells != null)
            {
                for (int i = 0; i < Spells.Length; i++)
                {
                    parent.GetComponent<ICombatSystem>().Get<ISpellSystem>()?.AddSpell(i, Spells[i]);
                }
            }

            Events.CloakEquipped(this);
        }

        public bool IsEquipped
        {
            get
            {
                return State.CloakObject;
            }
        }

        public void Unequip()
        {
            Destroy(State.CloakObject);
            State.CloakObject = null;

            Events.CloakUnequipped(this);
        }
    }
}
