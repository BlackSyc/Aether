using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObject : MonoBehaviour
{
    public void Destroy()
    {
        GetComponent<Animation>().Play("HintDespawn");
        StopAllCoroutines();
        Destroy(gameObject, .5f);
    }
}
