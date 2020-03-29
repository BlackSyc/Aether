using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject hintContainerPrefab;

    [SerializeField]
    private RectTransform content;

    private void Start()
    {
        Hint.Events.OnActivated += ShowHint;
    }

    public void ShowHint(Hint hint)
    {
        GameObject hintContainer = GameObject.Instantiate(hintContainerPrefab, content);
        GameObject.Instantiate(hint.HintPrefab, hintContainer.transform); ;
    }

    private void OnDestroy()
    {
        Hint.Events.OnActivated -= ShowHint;
    }
}
