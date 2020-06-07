using Aether.Combat.TargetSystem;
using Aether.Input;
using UnityEngine;

namespace Aether.Combat.SpellSystem.Private
{
    internal class PlayerSpellSystem : SpellSystem
    {

        [SerializeField]
        private PlayerTargetSystem playerTargetSystem;

        #region MonoBehaviour
        private void Start() => SubscribeToInput();


        private void OnDestroy() => UnsubscribeFromInput();
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            InputSystem.InputActions.Player.CastSpell1.performed += _ => CastSpell(0, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell2.performed += _ => CastSpell(1, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell3.performed += _ => CastSpell(2, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell4.performed += _ => CastSpell(3, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell5.performed += _ => CastSpell(4, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell6.performed += _ => CastSpell(5, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell7.performed += _ => CastSpell(6, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CancelCast.performed += _ => CancelSpellCast();
        }
        private void UnsubscribeFromInput()
        {
            InputSystem.InputActions.Player.CastSpell1.performed -= _ => CastSpell(0, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell2.performed -= _ => CastSpell(1, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell3.performed -= _ => CastSpell(2, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell4.performed -= _ => CastSpell(3, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell5.performed -= _ => CastSpell(4, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell6.performed -= _ => CastSpell(5, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CastSpell7.performed -= _ => CastSpell(6, playerTargetSystem.GetCurrentTarget());
            InputSystem.InputActions.Player.CancelCast.performed -= _ => CancelSpellCast();
        }
        #endregion
    }
}
