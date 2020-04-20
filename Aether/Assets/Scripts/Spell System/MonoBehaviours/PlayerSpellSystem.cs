using static Aether.InputSystem.InputSystem;

namespace Aether.SpellSystem
{
    public class PlayerSpellSystem : SpellSystem
    {

        #region MonoBehaviour
        private void Start()
        {
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
            InputActions inputActions = Input;
            Input.Player.CastSpell1.performed += _ => CastSpell(0);
            Input.Player.CastSpell2.performed += _ => CastSpell(1);
            Input.Player.CastSpell3.performed += _ => CastSpell(2);
            Input.Player.CastSpell4.performed += _ => CastSpell(3);
            Input.Player.CastSpell5.performed += _ => CastSpell(4);
            Input.Player.CastSpell6.performed += _ => CastSpell(5);
            Input.Player.CastSpell7.performed += _ => CastSpell(6);
            Input.Player.CancelCast.performed += _ => CancelSpellCast();
        }
        private void UnsubscribeFromInput()
        {
            Input.Player.CastSpell1.performed -= _ => CastSpell(0);
            Input.Player.CastSpell2.performed -= _ => CastSpell(1);
            Input.Player.CastSpell3.performed -= _ => CastSpell(2);
            Input.Player.CastSpell4.performed -= _ => CastSpell(3);
            Input.Player.CastSpell5.performed -= _ => CastSpell(4);
            Input.Player.CastSpell6.performed -= _ => CastSpell(5);
            Input.Player.CastSpell7.performed -= _ => CastSpell(6);
            Input.Player.CancelCast.performed -= _ => CancelSpellCast();
        }
        #endregion
    }
}
