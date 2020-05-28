namespace Aether.Core.Interaction
{
    public interface IInteractable
    {
        string InteractionMessage { get; set; }
        bool IsActive { get; set; }
    }
}
