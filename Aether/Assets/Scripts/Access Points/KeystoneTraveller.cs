using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystoneTraveller : MonoBehaviour
{

    public Camera Camera;

    [SerializeField]
    private Animator animator;

    public void Travel(float progress)
    {
        animator.Play("Travel", -1, progress);
    }

    public void TravelBack(float progress)
    {
        animator.Play("TravelBack", -1, progress);
    }


}
