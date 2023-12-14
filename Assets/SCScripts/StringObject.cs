using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1)]
public class StringObject : ScriptableObject
{
    public string value;
    public string defaultValue;

    public void Reset()
    {
        value = defaultValue;
    }
}
