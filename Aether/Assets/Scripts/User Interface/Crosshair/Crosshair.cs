using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private TargetManager targetManager;

    [SerializeField]
    private RectTransform targetLock;

    [SerializeField]
    private Camera camera;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("HasObjectTarget", targetManager.GetCurrentTarget().HasTargetTransform);
        targetLock.anchoredPosition = Vector2.zero;
        if (targetManager.HasLockedTarget)
        {
            targetLock.position = camera.WorldToScreenPoint(targetManager.GetCurrentTarget().Position);
        }
    }
}
