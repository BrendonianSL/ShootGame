using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    public int damage;
    public int currentAmmo;
    public int maxAmmo;
    public int fireRate;
    public bool isReloading;
    public float reloadTime;
}
