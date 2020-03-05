using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class KeepAbsolutePosition : MonoBehaviour
{
    [SerializeField]
    private bool active = true;

    private RectTransform rectTransform;

    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private Vector3 currentPosition;
    
    protected void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        currentPosition = transform.position;
        if (startPosition != null && active)
        {
            rectTransform.position = startPosition;
        }
    }
}
