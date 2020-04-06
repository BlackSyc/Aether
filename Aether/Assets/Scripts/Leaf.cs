using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public void DespawnPlatform()
    {
        GetComponent<Animator>().SetBool("Spawn", false);
    }

    public void SpawnPlatform()
    {
        GetComponent<Animator>().SetBool("Spawn", true);
    }
}
