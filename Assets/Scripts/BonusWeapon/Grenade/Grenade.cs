using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionEffect;
    public float delay = 3f;

    public float explosionForce = 7f;
    public float explosionRadius = 10f;

    public int grenadeDamage;

    void Start()
    {
        Invoke("Explode", delay);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        HashSet<EnemyHeatlhManager> enemyHeatlhManagerHashSet = new HashSet<EnemyHeatlhManager>();
        
        foreach (Collider nextTo in colliders)
        {
            Rigidbody rigidbody = nextTo.GetComponent<Rigidbody>();
            EnemyHeatlhManager enemyHealthManager = nextTo.GetComponentInParent<EnemyHeatlhManager>();

            
            if (enemyHealthManager != null)
            {
                if (!enemyHeatlhManagerHashSet.Contains(enemyHealthManager))
                {
                    enemyHealthManager.DamageEnemy(grenadeDamage);
                    enemyHeatlhManagerHashSet.Add(enemyHealthManager);
                }
            }


            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1f, ForceMode.Impulse);
            }

            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
