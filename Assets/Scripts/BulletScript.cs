using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rB;
    public float speed;
    public GunSO gunStats;
    // Start is called before the first frame update
    void Start()
    {
        speed = gunStats.firePwr;
        rB = GetComponent<Rigidbody>();
        rB.AddRelativeForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
