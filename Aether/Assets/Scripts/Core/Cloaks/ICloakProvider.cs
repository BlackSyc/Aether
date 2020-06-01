namespace Aether.Core.Cloaks
{
    public interface ICloakProvider
    {
        ICloak Cloak { get; }

        void Equip();

        void Unequip();
    }
}
