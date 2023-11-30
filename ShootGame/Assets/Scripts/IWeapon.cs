using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
   void Shoot()
   {

   }

   public IEnumerator ReloadWeapon()
   {
        yield return null;
   }
}
