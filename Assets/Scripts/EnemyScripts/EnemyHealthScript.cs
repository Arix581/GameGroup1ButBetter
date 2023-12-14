using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : HealthScript
{
    //public FloatObject points;
    //public float pointsOnDeath;
    public bool delOnDie = true;
    public override void Die()
    {
        base.Die();
        //points.value += pointsOnDeath;
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
