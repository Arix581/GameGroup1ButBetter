using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunSO : ScriptableObject
{
    public float fireRate;
    public float firePwr;
    public float reloadTime;
    public float damage;
    public float recoilLvl;
    public float knockBack;
    public float AOE;
    public float maxAmo;
}
