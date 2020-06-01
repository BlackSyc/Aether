using Aether.Assets.Assemblies.Core.Items;
using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Interaction;
using Aether.Core.Items.ScriptableObjects;
using UnityEngine;

namespace Aether.StartPlatform
{
    public class Stairs : MonoBehaviour
    {
        [SerializeField]
        private Aspect aspect;

        [SerializeField]
        private Leaf leaf;

        public Aspect Aspect => aspect;

        [SerializeField]
        private IInteractable interactable;

        private Animator animator;

        [SerializeField]
        private Keystone grantKeystone;
        void Start()
        {
            animator = GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;

            Core.Cloaks.Events.OnCloakEquipped += CloakEquipped;
            Core.Cloaks.Events.OnCloakUnequipped += CloakUnequipped;
        }

        private void CloakEquipped(ICloak cloakInfo)
        {
            if (cloakInfo.Aspect.Equals(aspect))
            {
                interactable.IsActive = true;
                animator.SetBool("activated", true);
            }
        }

        private void CloakUnequipped(ICloak cloakInfo)
        {
            if (cloakInfo.Aspect.Equals(aspect))
            {
                interactable.IsActive = false;
                animator.SetBool("activated", false);
                leaf.DespawnPlatform();
            }
        }

        public void MoveStairs()
        {
            animator.SetTrigger("move");
            interactable.IsActive = false;
            leaf.SpawnPlatform();

            GrantKeystone();
        }

        private void GrantKeystone()
        {
            if (grantKeystone != null)
            {
                Player.Instance.Get<IInventory>().PickupKeystone(grantKeystone);
                grantKeystone = null;
            }
        }



        // Update is called once per frame
        void OnDestroy()
        {
            Core.Cloaks.Events.OnCloakEquipped -= CloakEquipped;
            Core.Cloaks.Events.OnCloakUnequipped -= CloakUnequipped;
        }
    }
}
