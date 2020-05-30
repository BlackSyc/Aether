namespace Aether.Core.Combat
{
    public interface IModifier
    {
        IModifierType ModifierType { get; }

        float FallOffTime { get; set; }
    }
}
