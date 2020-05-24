namespace Aether.Combat.Panels
{
    public class PlayerCombatPanel : CombatPanel
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            combatSystem = Player.Instance.CombatSystem;

            if (healthBar != null)
                LinkHealthBar();

            if (modifiersBar != null)
                LinkModifiersBar();
        }

        // Update is called once per frame
        protected override void Update()
        {

        }
    }
}
