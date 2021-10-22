using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmAreaOfEffectController : MonoBehaviour
{
    private HashSet<EnemyHeatlhManager> objectsInsideOfNapalmArea = new HashSet<EnemyHeatlhManager>();
    
    public int damagePerTick = 10;

    public float totalDurationTime;
    public float intervalBetweenTicks;

    void Start()
    {
        StartCoroutine("NapalmDamageOverTime");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            objectsInsideOfNapalmArea.Add(other.gameObject.GetComponentInParent<EnemyHeatlhManager>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            objectsInsideOfNapalmArea.Remove(other.gameObject.GetComponentInParent<EnemyHeatlhManager>());
        }
    }

    private IEnumerator NapalmDamageOverTime()
    {
        float currentDurationTime = 0;
        

        while (currentDurationTime < totalDurationTime)
        {
            foreach (var enemyInsideOfNapalm in objectsInsideOfNapalmArea)
            {
                if (enemyInsideOfNapalm == null)
                {
                    continue;
                }

                enemyInsideOfNapalm.DamageEnemy(damagePerTick);
            }

            currentDurationTime += intervalBetweenTicks;
            yield return new WaitForSeconds(intervalBetweenTicks);

        }

        Destroy(gameObject);
    }

}
