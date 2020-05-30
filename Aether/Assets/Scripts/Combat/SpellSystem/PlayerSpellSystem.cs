using Aether.Input;
using static Aether.Input.InputSystem;

namespace Aether.Combat.SpellSystem.Private
{
    internal class PlayerSpellSystem : SpellSystem
    {

        #region MonoBehaviour
        private void Start() => SubscribeToInput();
        

        private void OnDestroy() => UnsubscribeFromInput();
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            InputSystem.InputActions.Player.CastSpell1.performed += _ => CastSpell(0);
            InputSystem.InputActions.Player.CastSpell2.performed += _ => CastSpell(1);
            InputSystem.InputActions.Player.CastSpell3.performed += _ => CastSpell(2);
            InputSystem.InputActions.Player.CastSpell4.performed += _ => CastSpell(3);
            InputSystem.InputActions.Player.CastSpell5.performed += _ => CastSpell(4);
            InputSystem.InputActions.Player.CastSpell6.performed += _ => CastSpell(5);
            InputSystem.InputActions.Player.CastSpell7.performed += _ => CastSpell(6);
            InputSystem.InputActions.Player.CancelCast.performed += _ => CancelSpellCast();
        }
        private void UnsubscribeFromInput()
        {
            InputSystem.InputActions.Player.CastSpell1.performed -= _ => CastSpell(0);
            InputSystem.InputActions.Player.CastSpell2.performed -= _ => CastSpell(1);
            InputSystem.InputActions.Player.CastSpell3.performed -= _ => CastSpell(2);
            InputSystem.InputActions.Player.CastSpell4.performed -= _ => CastSpell(3);
            InputSystem.InputActions.Player.CastSpell5.performed -= _ => CastSpell(4);
            InputSystem.InputActions.Player.CastSpell6.performed -= _ => CastSpell(5);
            InputSystem.InputActions.Player.CastSpell7.performed -= _ => CastSpell(6);
            InputSystem.InputActions.Player.CancelCast.performed -= _ => CancelSpellCast();
        }
        #endregion
    }
}
