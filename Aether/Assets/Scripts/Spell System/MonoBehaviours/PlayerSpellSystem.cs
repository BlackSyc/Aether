using static Aether.InputSystem.GameInputSystem;
using System;

namespace Aether.SpellSystem
{
    public class PlayerSpellSystem : SpellSystem
    {

        #region MonoBehaviour
        protected override void Awake()
        {
            base.Awake();
            SubscribeToInput();
        }

        private void OnDestroy()
        {
            UnsubscribeFromInput();
        }
        #endregion

        #region Input
        private void SubscribeToInput()
        {
            PlayerInput.Player.CastSpell1.performed += _ => CastSpell(0);
            PlayerInput.Player.CastSpell2.performed += _ => CastSpell(1);
            PlayerInput.Player.CastSpell3.performed += _ => CastSpell(2);
            PlayerInput.Player.CastSpell4.performed += _ => CastSpell(3);
            PlayerInput.Player.CastSpell5.performed += _ => CastSpell(4);
            PlayerInput.Player.CastSpell6.performed += _ => CastSpell(5);
            PlayerInput.Player.CastSpell7.performed += _ => CastSpell(6);
            PlayerInput.Player.CancelCast.performed += _ => CancelSpellCast();
        }
        private void UnsubscribeFromInput()
        {
            PlayerInput.Player.CastSpell1.performed -= _ => CastSpell(0);
            PlayerInput.Player.CastSpell2.performed -= _ => CastSpell(1);
            PlayerInput.Player.CastSpell3.performed -= _ => CastSpell(2);
            PlayerInput.Player.CastSpell4.performed -= _ => CastSpell(3);
            PlayerInput.Player.CastSpell5.performed -= _ => CastSpell(4);
            PlayerInput.Player.CastSpell6.performed -= _ => CastSpell(5);
            PlayerInput.Player.CastSpell7.performed -= _ => CastSpell(6);
            PlayerInput.Player.CancelCast.performed -= _ => CancelSpellCast();
        }
        #endregion
    }
}
