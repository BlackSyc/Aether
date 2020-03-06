using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakObjectParent : MonoBehaviour
{
    [SerializeField]
    private float showDelay = 2;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private CloakInfo cloakInfo;

    private void Start()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnShowCloaks += Show;    
    }

    private void Show()
    {
        StartCoroutine(ShowAfter(showDelay));
    }

    private IEnumerator ShowAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cloakObject.SetActive(true);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.Puzzle1Events.OnShowCloaks -= Show;
    }


}
