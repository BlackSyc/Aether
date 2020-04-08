using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour, ILevelController
{
    [SerializeField]
    private Transform entryPoint;

    [SerializeField]
    private bool DisableOnStart = true;

    protected virtual void Start()
    {
        if (gameObject.scene.buildIndex.Equals(SceneController.Instance.LoadedLevel.buildIndex))
        {
            SceneController.Instance.LoadedLevel.levelController = this;
        }

        if (DisableOnStart)
        {
            Disable();
        }
    }

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    public Transform GetEntryPoint()
    {
        return entryPoint;
    }
}

