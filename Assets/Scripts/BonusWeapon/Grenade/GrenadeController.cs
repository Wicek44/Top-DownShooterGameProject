using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] private Transform throwingWeaponGrip;
    [SerializeField] private GameObject grenade;
    [SerializeField] private Rigidbody grenadeRigidbody;
    [SerializeField] private float throwRange;

    private PlayerHealthManager playerHealthManager;
    private EnemySpawnManager enemySpawnManager;

    private bool isGrenadePickedUp = false;

    public void Start()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
    }

    void FixedUpdate()
    {
        if (playerHealthManager.playerDied == true || enemySpawnManager.IsLevelFinished == true)
        {
            return;
        }

        if (playerHealthManager.playerDied == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (isGrenadePickedUp == true)
                {
                    ThrowGreande();
                    isGrenadePickedUp = false;
                }

            }
        }
    }

    private void ThrowGreande()
    {
        GameObject grenadeReadyToThrow = Instantiate(grenade, throwingWeaponGrip.position, throwingWeaponGrip.rotation);
        grenadeReadyToThrow.GetComponent<Rigidbody>().AddForce(throwingWeaponGrip.forward * throwRange, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grenade")
        {
            isGrenadePickedUp = true;
            Destroy(collision.gameObject);
        }
    }

}
