using Aether.Core;
using Aether.Core.Attributes;
using UnityEngine;

public class Logger : MonoBehaviour
{
    [ContextMenu("Log movement speed")]
    public void LogMovementSpeed()
    {
        Debug.Log(Player.Instance.GetComponent<ScryerAttributes>().MovementSpeed.CurrentValue);
    }
}
