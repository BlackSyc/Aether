﻿using System;
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
}
