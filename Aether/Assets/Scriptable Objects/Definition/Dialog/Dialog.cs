using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialog/Dialog")]
public class Dialog : ScriptableObject
{
    public List<DialogLine> dialogLines;

    public event Action OnComplete;

    public DialogLine GetDialogLine(string name)
    {
        return dialogLines.FirstOrDefault(x => x.Name.Equals(name));
    }

    public void Complete()
    {
        if(OnComplete == null)
            return;

        OnComplete();
    }
}
