using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     to get objects like ECS
/// </summary>
public abstract class GatherBehaviour<T> : MonoBehaviour where T : class
{
    private static readonly List<T> Behaviours = new List<T>();
    public static T[] All { get; private set; } = new T[0];

    protected virtual void Awake()
    {
        Behaviours.Add(this as T);
        All = Behaviours.ToArray();
        OnNew?.Invoke(this as T);
    }

    protected void OnDestroy()
    {
        Behaviours.Remove(this as T);
    }

    public static event Action<T> OnNew;
}