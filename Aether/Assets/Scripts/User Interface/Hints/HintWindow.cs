using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintWindow : MonoBehaviour
{

    [SerializeField]
    private RectTransform content;

    private void Start()
    {
        Hint.Events.OnActivated += ShowHint;
    }

    public void ShowHint(Hint hint)
    {
        GameObject hintObject = GameObject.Instantiate(hint.HintPrefab, content);
    }

    private void OnDestroy()
    {
        Hint.Events.OnActivated -= ShowHint;
    }
}
