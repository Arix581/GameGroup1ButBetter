using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0)]
public class BoolObject : ScriptableObject
{
    public bool value;
    public bool defaultValue;
    
    public void Reset()
    {
        value = defaultValue;
    }
}
