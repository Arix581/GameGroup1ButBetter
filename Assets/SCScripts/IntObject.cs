using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 3)]
public class IntObject : ScriptableObject
{
    public int value;
    public int defaultValue;

    public void Reset()
    {
        value = defaultValue;
    }

    public void Add(int other)
    {
        value += other;
    }
}
