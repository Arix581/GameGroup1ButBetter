using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rB;
    private float speed;
    public GunSO gunStats;
    // Start is called before the first frame update
    void Start()
    {
        speed = gunStats.firePwr;
        rB = GetComponent<Rigidbody>();
        rB.AddForce(transform.up * speed, ForceMode.Impulse);
        Debug.Log(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealthScript>().TakeDamage(gunStats.damage);
        }
    }
}
