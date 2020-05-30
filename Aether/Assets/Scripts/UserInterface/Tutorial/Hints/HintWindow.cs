using Aether.Core.Tutorial;
using UnityEngine;

public class HintWindow : MonoBehaviour
{
    [SerializeField]
    private RectTransform hintParent;

    private void Awake() => Hint.Events.OnActivated += ShowHint;
    private void OnDestroy() => Hint.Events.OnActivated -= ShowHint;

    public void ShowHint(Hint hint) => Instantiate(hint.HintPrefab, hintParent);

}
