using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionBehavior : MonoBehaviour
{
    public UnityEvent colliderEnter;
    public Collider otherColider;

    private void OnCollisionEnter(Collision collision)
    {
        otherColider = collision.collider;
        colliderEnter.Invoke();
    }
}
