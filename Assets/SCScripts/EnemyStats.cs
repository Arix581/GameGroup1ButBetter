using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public float speed = 4.5f;
    public float damage = 1f;
    public bool canDash = false;
}
