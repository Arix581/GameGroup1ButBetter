using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 2)]
public class FloatObject : ScriptableObject
{
    public float value;
    public float defaultValue;

    public virtual void Reset()
    {
        value = defaultValue;
    }

    public virtual void Add(float other)
    {
        value += other;
    }
}
