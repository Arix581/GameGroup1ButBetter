using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    private void Start()
    {
        OnStartHealth();
    }

    public virtual void OnStartHealth()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(name + " died.");
    }
}
