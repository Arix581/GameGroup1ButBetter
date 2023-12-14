using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent triggerEnter;
    public Collider otherColider;

    private void OnTriggerEnter(Collider other)
    {
        otherColider = other;
        triggerEnter.Invoke();
    }
}
