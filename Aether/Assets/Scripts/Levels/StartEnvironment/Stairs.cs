using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Interaction;
using UnityEngine;

namespace Aether.Levels.StartEnvironment
{
    [RequireComponent(typeof(IInteractable))]
    [RequireComponent(typeof(Animator))]
    public class Stairs : MonoBehaviour
    {
        private Animator animator;

        private IInteractable interactable;

        void Start()
        {
            interactable = GetComponent<IInteractable>();

            animator = GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;

            if (Player.Instance.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged += OnPlayerCloakEquipped;
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
            if (Player.Instance.Has(out IShoulder shoulder))
                shoulder.OnCloakChanged -= OnPlayerCloakEquipped;
        }
    }
}
