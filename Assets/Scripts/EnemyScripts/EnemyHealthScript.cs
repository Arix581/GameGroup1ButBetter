using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthScript : HealthScript
{
    //public FloatObject points;
    //public float pointsOnDeath;
    public bool delOnDie = true;
    public UnityEvent onDie;
    public override void Die()
    {
        base.Die();
        //points.value += pointsOnDeath;
        onDie.Invoke();
        if (delOnDie)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
