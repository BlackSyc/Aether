using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager _instance;

    [SerializeField]
    private DialogWindow dialogWindow;

    private void Awake()
    {
        _instance = this;
    }

    public static DialogWindow GetDialogWindow()
    {
        return _instance.dialogWindow;
    }
}
