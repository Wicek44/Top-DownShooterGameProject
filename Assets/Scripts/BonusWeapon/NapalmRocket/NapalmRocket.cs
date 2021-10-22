using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmRocket : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject napamlAreaOfEffectController;
    
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(napamlAreaOfEffectController, new Vector3(transform.position.x, 0, transform.position.z), napamlAreaOfEffectController.transform.rotation);
        Destroy(gameObject);
    }

}
