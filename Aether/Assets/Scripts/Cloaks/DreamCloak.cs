using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCloak : MonoBehaviour
{
    [SerializeField]
    private GameObject robinPrefab;

    [SerializeField]
    private Keystone spawnRobinIfFound;

    private void Start()
    {
        if(spawnRobinIfFound.IsFound && !Player.Instance.Companion)
        {
            Companion companion = GameObject.Instantiate(robinPrefab, Player.Instance.transform.position + new Vector3(0, 5, 0), Quaternion.identity).GetComponent<Companion>();
            Player.Instance.Companion = companion;
        }
    }
}
