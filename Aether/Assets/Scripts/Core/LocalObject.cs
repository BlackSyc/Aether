using MLAPI;
using UnityEngine;

public class LocalObject : MonoBehaviour
{
    [SerializeField] private NetworkedBehaviour owner;

    private void Start()
    {
        if (!owner.IsLocalPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
