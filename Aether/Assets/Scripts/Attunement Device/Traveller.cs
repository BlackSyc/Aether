using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveller : MonoBehaviour
{
    public AnimationClip TravelAnimation;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator PlayAnimation(bool reverse)
    {
        Debug.Log("Start travel");
        Player.Instance.gameObject.transform.parent = gameObject.transform;
        Player.Instance.PlayerMovement.enabled = false;

        if (reverse)
        {
            animator.Play($"{TravelAnimation.name}Reverse");
        }
        else
        {
            animator.Play($"{TravelAnimation.name}");
        }
        yield return new WaitForSeconds(TravelAnimation.length);

        Player.Instance.gameObject.transform.parent = null;
        SceneManager.MoveGameObjectToScene(Player.Instance.gameObject, SceneManager.GetSceneByName("PlayerScene"));
        Player.Instance.PlayerMovement.enabled = true;
        Debug.Log("End travel");
    }
}
