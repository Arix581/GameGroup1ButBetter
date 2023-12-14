using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : HealthScript
{
    public FloatObject playerHealth;
    public float resistanceMultiplier = 1;
    public float invincibilityTime = 2.5f;

    [SerializeField] private FloatObject invinsibilityRemaining;

    private void Update()
    {
        if (invinsibilityRemaining.value > 0f)
        {
            invinsibilityRemaining.value = Mathf.Clamp(invinsibilityRemaining.value - Time.deltaTime, -1f, invincibilityTime);
        }
    }

    public override void TakeDamage(float Amount)
    {
        health = playerHealth.value;
        base.TakeDamage(Amount * resistanceMultiplier);
        playerHealth.value = Mathf.Clamp(health, 0f, maxHealth);
        Debug.Log("Player took " + Amount.ToString() + " damage.");
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision on layer " + collision.gameObject.layer);

        bool isEnemyLayer = collision.gameObject.layer == 7;

        if (invinsibilityRemaining.value > 0f && isEnemyLayer)
        {
            Debug.Log("Collision with enemy while invincible");
        }
        else if (invinsibilityRemaining.value <= 0f && isEnemyLayer)
        {
            Debug.Log("Collsion with enemy");
            collision.gameObject.GetComponent<EnemyAI>().DamagePlayer();
            invinsibilityRemaining.value = invincibilityTime;
        }
    }

    public override void OnStartHealth()
    {
        playerHealth.Reset();
    }
}
