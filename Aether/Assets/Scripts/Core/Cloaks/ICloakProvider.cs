using Aether.Core.Interaction;

namespace Aether.Core.Cloaks
{
    public interface ICloakProvider
    {
        ICloak Cloak { get; }

        void Equip(IInteractor interactor);

        void Unequip(IInteractor interactor);
    }
}
