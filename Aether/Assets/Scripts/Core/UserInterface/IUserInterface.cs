using UnityEngine;

namespace Aether.Core.UserInterface
{
    public interface IUserInterface
    {
        RectTransform GetContainer(UIContainer containerType);
    }
}
