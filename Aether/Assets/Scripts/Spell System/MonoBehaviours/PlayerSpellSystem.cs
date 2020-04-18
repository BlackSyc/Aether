namespace Aether.SpellSystem
{
    public class PlayerSpellSystem : SpellSystem
    {
        #region Private Fields
        private InputActions inputActions;
        #endregion

        #region MonoBehaviour
        private void Start()
        {
            inputActions = new InputActions();
            SubscribeToInputActions();
        }

        private void OnEnable()
        {
            inputActions.Player.CastSpell1.Enable();
            inputActions.Player.CastSpell2.Enable();
            inputActions.Player.CastSpell3.Enable();
            inputActions.Player.CastSpell4.Enable();
            inputActions.Player.CastSpell5.Enable();
            inputActions.Player.CastSpell6.Enable();
            inputActions.Player.CastSpell7.Enable();

            inputActions.Player.CancelCast.Enable();
        }

        private void OnDisable()
        {
            inputActions.Player.CastSpell1.Disable();
            inputActions.Player.CastSpell2.Disable();
            inputActions.Player.CastSpell3.Disable();
            inputActions.Player.CastSpell4.Disable();
            inputActions.Player.CastSpell5.Disable();
            inputActions.Player.CastSpell6.Disable();
            inputActions.Player.CastSpell7.Disable();

            inputActions.Player.CancelCast.Disable();

        }
        #endregion

        #region Input
        private void SubscribeToInputActions()
        {
            inputActions.Player.CastSpell1.performed += _ => base.CastSpell(0);
            inputActions.Player.CastSpell2.performed += _ => base.CastSpell(1);
            inputActions.Player.CastSpell3.performed += _ => base.CastSpell(2);
            inputActions.Player.CastSpell4.performed += _ => base.CastSpell(3);
            inputActions.Player.CastSpell5.performed += _ => base.CastSpell(4);
            inputActions.Player.CastSpell6.performed += _ => base.CastSpell(5);
            inputActions.Player.CastSpell7.performed += _ => base.CastSpell(6);
            inputActions.Player.CancelCast.performed += _ => base.CancelSpellCast();
        }
        #endregion
    }
}
