using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialog/Dialog")]
public class Dialog : ScriptableObject
{
    public List<DialogLine> dialogLines;

    private UnityAction onComplete;

    public DialogLine Line(string name)
    {
        return dialogLines.FirstOrDefault(x => x.Name.Equals(name));
    }

    public void Complete()
    {
        onComplete?.Invoke();
    }

    public void OnComplete(UnityAction onComplete)
    {
        this.onComplete = onComplete;
    }

    public void Start()
    {
        WindowManager.GetDialogWindow().StartDialog(this);
    }
}
