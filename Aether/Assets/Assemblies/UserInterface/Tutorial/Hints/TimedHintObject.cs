using Aether.Core.Tutorial;
using System.Collections;
using UnityEngine;

public class TimedHintObject : HintObject
{
    [SerializeField]
    private float deactivateAfter = 3f;

    private void Start()
    {
        StartCoroutine(DeactivateAfter(deactivateAfter));
    }

    private IEnumerator DeactivateAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy();
    }
}
