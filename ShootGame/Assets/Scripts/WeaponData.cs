using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/New Weapon")]
public class WeaponData : ScriptableObject
{
    public int damage;
    public int currentAmmo;
    public int maxAmmo;
    public int fireRate;

    public float reloadTime;

    public bool isReloading;
    public bool isAutomatic;
}
