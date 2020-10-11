using Syc.Core.Interaction;

namespace Aether.Core.Cloaks
{
    public interface ICloakProvider
    {
        ICloak Cloak { get; }

        void Equip(Interactor interactor);

        void Unequip(Interactor interactor);
    }
}
