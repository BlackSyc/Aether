using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeystoneLabel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public void SetText(string labelText)
    {
        _text.text = labelText;
    }
}
