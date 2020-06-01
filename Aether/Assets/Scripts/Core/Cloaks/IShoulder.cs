namespace Aether.Core.Cloaks
{
    public interface IShoulder
    {
        ICloak EquippedCloak { get; }

        void EquipCloak(ICloak cloak);

        void UnequipCloak();
    }
}
