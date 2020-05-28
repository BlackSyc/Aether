using Aether.Core.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TransitionPanel : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        LevelEntry.Events.OnEnteringLevel += PlayAnimation;
        LevelExit.Events.OnExitingLevel += PlayAnimation;
    }

    private void PlayAnimation()
    {
        animator.SetTrigger("Transition");
    }

    private void OnDestroy()
    {
        LevelEntry.Events.OnEnteringLevel -= PlayAnimation;
        LevelExit.Events.OnExitingLevel -= PlayAnimation;

    }
}
