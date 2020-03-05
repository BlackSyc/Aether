using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyXRotation : MonoBehaviour
{
    [SerializeField]
    private Transform source;

    void LateUpdate()
    {
        this.transform.rotation = Quaternion.Euler(source.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
    }
}
