using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponData weaponData;
    
    private float timeSinceLastShot;

    private bool CanShoot() => !weaponData.isReloading && timeSinceLastShot > 1f / (weaponData.fireRate / 60f);

    void Awake()
    {
          weaponData = ScriptableObject.Instantiate(weaponData);
    }
    
    void Update()
    {
          timeSinceLastShot += Time.deltaTime;
          if(weaponData.currentAmmo<=0)
          {
               StartCoroutine(ReloadWeapon());
          }
    }

    void Shoot()
   {
          if(weaponData.isReloading || !CanShoot() || weaponData.currentAmmo <= 0)
          {
               return;
          }
          timeSinceLastShot = 0f;
          weaponData.currentAmmo--;
   }

    public IEnumerator ReloadWeapon()
   {
        yield return null;
   }
}
