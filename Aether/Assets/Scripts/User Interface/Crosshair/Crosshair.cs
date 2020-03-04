using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private TargetManager targetManager;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetBool("HasObjectTarget", targetManager.GetCurrentTarget().HasTargetObject);
    }
}
