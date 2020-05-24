using Aether.Combat.Modifiers;
using Aether.Combat.SpellSystem;

public class Sprint : SpellObject
{
    public override void CastCanceled()
    {
    }

    public override void CastFired()
    {
        if (Target.Has(out IModifierSlots modifierSlots))
            modifierSlots.AddModifier(new Modifier(Spell.Modifiers[0]));
        Destroy(gameObject);
    }

    public override void CastInterrupted()
    {
    }

    public override void CastStarted()
    {
    }
}
