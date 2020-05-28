namespace Aether.Core.Interaction
{
    public interface IInteractor
    {
        T Get<T>();

        bool Has<T>(out T t);
    }
}
