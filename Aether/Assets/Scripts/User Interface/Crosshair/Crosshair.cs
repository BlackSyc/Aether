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
    private GameObject targetTracker;

    [SerializeField]
    private Camera camera;

    // Update is called once per frame
    void LateUpdate()
    {
        if(targetManager.GetCurrentTarget().HasTargetTransform)
        {
            if (targetManager.HasLockedTarget && targetManager.GetCurrentTarget().TargetTransform == targetManager.Target.TargetTransform)
            {
                GetComponent<Animator>().SetBool("HasObjectTarget", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("HasObjectTarget", true);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("HasObjectTarget", false);
        }

        if (targetManager.HasLockedTarget)
        {
            targetTracker.SetActive(true);
            targetTracker.GetComponent<RectTransform>().position = camera.WorldToScreenPoint(targetManager.Target.Position);
        }
        else
        {
            targetTracker.SetActive(false);
        }
    }
}
