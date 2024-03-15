using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bSpawn;
    public GameObject randomGun;
    public GunSO gunStats;
    public float time;
    public float timer;
    public bool ableToFire;
    public float ammo;
    public float maxAmmo;
    public float rTimer;
    public float rTime;
    public bool reloading;
    public float spread;
    public Vector2 mouseInput;

    private void Start()
    {
        time = gunStats.fireRate;
        timer = time;
        maxAmmo = gunStats.maxAmo;
        ammo = maxAmmo;
        rTime = gunStats.reloadTime;
        rTimer = rTime;
        spread = gunStats.spread / 2;
        Instantiate(randomGun);
    }

    // Update is called once per frame
    void Update()
    {

        if (ableToFire == false)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer <= 0)
        {
            timer = time;
            ableToFire = true;
        }

        if (ammo <= 0)
        {
            rTimer -= Time.deltaTime;
            reloading = true;
            if (rTimer <= 0)
            {
                ammo = maxAmmo;
                rTimer = rTime;
                reloading = false;
            }
        }

        if (Input.GetButton("Fire1") && ableToFire == true && reloading == false)
        {
            Instantiate(bullet, bSpawn.transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z + Random.Range(-spread, spread)));
            //b.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-spread, spread));
            ableToFire = false;
            ammo -= 1;
        }
    }

    
}
