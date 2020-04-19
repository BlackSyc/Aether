using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.InputSystem
{
    public interface IInputSystem
    {
        event Action<ActionMap> OnActionMapSwitched;

        InputActions InputActions { get; }

        ActionMap CurrentActionMap { get; }

        void SwitchToActionMap(ActionMap actionMap);
    }
}
