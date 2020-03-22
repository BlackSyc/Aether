using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class AetherEvents
{
    public struct KeystoneEvents
    {
        public static event Action<Keystone> OnKeystoneActivated;
        public static event Action<Keystone> OnKeystoneDeactivated;

        public static void KeystoneActivated(Keystone keystone)
        {
            OnKeystoneActivated?.Invoke(keystone);
        }

        public static void KeystoneDeactivated(Keystone keystone)
        {
            OnKeystoneDeactivated?.Invoke(keystone);
        }
    }
}

[CreateAssetMenu(menuName = "Scriptable Objects/Items/Keystone")]
public class Keystone : ScriptableObject
{
    public string Name;

    public Aspect Aspect;

    public List<string> Labels;

    [TextArea]
    public string Description;

    public Sprite Sprite;

    public bool KeystoneCompleted;

    public GameObject AccessPointPrefab;

    private KeystoneState state = new KeystoneState();

    private struct KeystoneState
    {
        public bool IsActivated;
    }

    public bool IsActivated => state.IsActivated;

    public void Activate()
    {
        state.IsActivated = true;
        AetherEvents.KeystoneEvents.KeystoneActivated(this);
    }

    public void Deactivate()
    {
        state.IsActivated = false;
        AetherEvents.KeystoneEvents.KeystoneDeactivated(this);
    }
}
