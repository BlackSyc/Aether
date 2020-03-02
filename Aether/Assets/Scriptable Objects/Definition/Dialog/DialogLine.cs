using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialog/DialogLine")]
public class DialogLine : ScriptableObject
{
    public string Name;

    public string Content;

    private UnityAction onComplete;

    public void Complete()
    {
        onComplete?.Invoke();
    }

    public void OnComplete(UnityAction onComplete)
    {
        this.onComplete = onComplete;
    }
}
