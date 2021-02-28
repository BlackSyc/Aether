using Aether.Core;
using Aether.Core.Cloaks;
using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(Animator))]
    public class Stairs : MonoBehaviour, ILocalPlayerLink
    {
        private Animator animator;

        private Interactable interactable;

        void Start()
        {
            interactable = GetComponent<Interactable>();

            animator = GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;

            Player.LinkToLocalPlayer(this);
        }

        private void OnPlayerCloakEquipped(ICloak cloak)
        {
            animator.SetBool("activated", cloak != null);
            interactable.IsActive = cloak != null;
        }

        public void MoveStairs()
        {
            animator.SetTrigger("move");
            interactable.IsActive = false;
        }

        // Update is called once per frame
        void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
        }

        public void OnLocalPlayerLinked(Player player)
        {
            if (player.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged += OnPlayerCloakEquipped;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            if (player.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged -= OnPlayerCloakEquipped;
        }
    }
}
