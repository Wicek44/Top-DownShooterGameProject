using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public float intervalBetweenBullets = 150;
    public float barrelSpeed = 20;
    float nextShootTime;
    [SerializeField] private GameObject muzzleFlash;

    public void Shooting()
    {
        if(Time.time > nextShootTime)
        {
            nextShootTime = Time.time + intervalBetweenBullets / 1000;
            Bullet newBullet = Instantiate(bullet, barrel.position, barrel.rotation) as Bullet;
            GameObject weaponFlash = Instantiate(muzzleFlash, barrel.transform.position, barrel.transform.rotation);
            weaponFlash.transform.SetParent(barrel);
            newBullet.SetBulletSpeed(barrelSpeed);
        }
    }
}
