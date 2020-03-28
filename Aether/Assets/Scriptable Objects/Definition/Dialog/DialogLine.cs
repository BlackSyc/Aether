using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialog/DialogLine")]
public class DialogLine : ScriptableObject
{
    public string Name;

    public string Speaker;
    public string Content;

    public event Action OnComplete;

    public void Complete()
    {
        if (OnComplete == null)
            return;

        OnComplete();
    }
}
