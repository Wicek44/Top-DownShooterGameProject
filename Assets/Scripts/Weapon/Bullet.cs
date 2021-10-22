using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 150;
    public int damagePerHit;
    public int bulletLifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    void Update()
    {
        float movementDistance = Time.deltaTime * bulletSpeed;

        transform.Translate(Vector3.forward * movementDistance);
    }

    public void SetBulletSpeed(float argBulletSpeed)
    {
        bulletSpeed = argBulletSpeed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponentInParent<EnemyHeatlhManager>().DamageEnemy(damagePerHit);
            Destroy(gameObject);
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Enviroment"))
        {
            Destroy(gameObject);
        }    
    }
}
