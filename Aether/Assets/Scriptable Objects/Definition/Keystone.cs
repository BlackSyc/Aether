using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Items/Keystone")]
public class Keystone : ScriptableObject
{
    public string Name;

    public List<string> Labels;

    [TextArea]
    public string Description;

    public Sprite Sprite;

    public bool KeystoneCompleted;

    public KeystoneState State = new KeystoneState();

    public struct KeystoneState
    {
        public bool IsActivated;
    }
}
