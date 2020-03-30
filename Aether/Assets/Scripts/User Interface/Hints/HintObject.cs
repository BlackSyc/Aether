using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObject : MonoBehaviour
{
    public void Destroy()
    {
        GetComponent<Animation>().Play("HintDespawn");
        Destroy(gameObject, 2.5f);
    }
}
