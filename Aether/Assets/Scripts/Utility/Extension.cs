using Aether.TargetSystem;
using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action(item);
        }
    }

    public static bool Contains(this LayerMask layerMask, GameObject gameObject)
    {
        return layerMask == (layerMask | (1 << gameObject.layer));
    }

    public static bool IsFriendly(this GameObject gameObject)
    {
        return Layers.FriendlyLayer.Contains(gameObject);
    }

    public static bool IsEnemy(this GameObject gameObject)
    {
        return Layers.EnemyLayer.Contains(gameObject);
    }

    public static LayerMask EnemyLayer(this GameObject gameObject)
    {
        return gameObject.IsFriendly() ? Layers.EnemyLayer : Layers.FriendlyLayer;
    }

    public static bool HasComponent<T>(this GameObject gameObject, out T component)
    {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    public static bool IsTarget(this GameObject gameObject, out ICombatComponent target)
    {
        bool result = gameObject.HasComponent(out target);
        return result;
    }
}
