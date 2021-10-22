using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon actuallyEquippedWeapon;
    
    public void ShootWeapon()
    {
        if(actuallyEquippedWeapon != null)
        {
            actuallyEquippedWeapon.Shooting();
        }
    }
}
