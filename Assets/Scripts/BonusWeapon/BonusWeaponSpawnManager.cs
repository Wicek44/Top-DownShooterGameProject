using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWeaponSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject grenadeToPickUpPrefab;
    [SerializeField] private GameObject napalmStrikeToPickUpPrefab;
    [SerializeField] private EnemySpawnManager enemySpawnManager;
    [SerializeField] private float timeToStartNextSpawnBonusWeapons;
    

    void Start()
    {
        enemySpawnManager.OnWaveActive += SpawnBonusWeapon;
        enemySpawnManager.OnLastWaveFinished += StopSpawnBonusWeapon;
    }

    private void SpawnBonusWeapon()
    {
        StartCoroutine("SpawnWithDelay");
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(10);

        Collider[] grenadeColliders;
        Collider[] napalmColliders;
        Vector3 grenadeSpawnPosition1st;
        Vector3 napalmSpawnPosition1st;
        var randomGrenadeX1 = UnityEngine.Random.Range(-7f, 7f);
        var randomGrenadeZ1 = UnityEngine.Random.Range(-7f, 7f);
        var randomNapalmX1 = UnityEngine.Random.Range(-7f, 7f);
        var randomNapalmZ1 = UnityEngine.Random.Range(-7f, 7f);

        do
        {
            grenadeSpawnPosition1st = new Vector3(randomGrenadeX1, 1f, randomGrenadeZ1);
            grenadeColliders = Physics.OverlapBox(grenadeSpawnPosition1st, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, LayerMask.NameToLayer("Enviroment"));

        } while (grenadeColliders.Length != 0);
        
        Instantiate(grenadeToPickUpPrefab, grenadeSpawnPosition1st, new Quaternion(0, 0, 0, 0));

        do
        {
            napalmSpawnPosition1st = new Vector3(randomNapalmX1, 1f, randomNapalmZ1);
            napalmColliders = Physics.OverlapBox(napalmSpawnPosition1st, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, LayerMask.NameToLayer("Enviroment"));

        } while (napalmColliders.Length != 0);

        Instantiate(napalmStrikeToPickUpPrefab, napalmSpawnPosition1st, new Quaternion(0, 0, 0, 0));


        yield return new WaitForSeconds(timeToStartNextSpawnBonusWeapons);

        Collider[] grenadeColliders2;
        Collider[] napalmColliders2;
        Vector3 grenadeSpawnPosition2nd;
        Vector3 napalmSpawnPosition2nd;
        var randomGrenadeX2 = UnityEngine.Random.Range(-7f, 7f);
        var randomGrenadeZ2 = UnityEngine.Random.Range(-7f, 7f);
        var randomNapalmX2 = UnityEngine.Random.Range(-7f, 7f);
        var randomNapalmZ2 = UnityEngine.Random.Range(-7f, 7f);

        do
        {
            grenadeSpawnPosition2nd = new Vector3(randomGrenadeX2, 1f, randomGrenadeZ2);
            grenadeColliders2 = Physics.OverlapBox(grenadeSpawnPosition2nd, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, LayerMask.NameToLayer("Enviroment"));

        } while (grenadeColliders2.Length != 0);

        Instantiate(grenadeToPickUpPrefab, grenadeSpawnPosition2nd, new Quaternion(0, 0, 0, 0));

        do
        {
            napalmSpawnPosition2nd = new Vector3(randomNapalmX2, 1f, randomNapalmZ2);
            napalmColliders2 = Physics.OverlapBox(napalmSpawnPosition2nd, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, LayerMask.NameToLayer("Enviroment"));

        } while (napalmColliders2.Length != 0);

        Instantiate(napalmStrikeToPickUpPrefab, napalmSpawnPosition2nd, new Quaternion(0, 0, 0, 0));
    }

    private void StopSpawnBonusWeapon()
    {
        StopAllCoroutines();
    }

}
