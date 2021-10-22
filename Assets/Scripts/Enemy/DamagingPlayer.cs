using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPlayer : MonoBehaviour
{
    [SerializeField] private int damageDoneToPlayer;
    [SerializeField] private Transform leftEnemyHand;
    [SerializeField] private Transform rightEnemyHand;

    public void DamagePlayerByRightHand()
    {
        Collider[] colliders = Physics.OverlapSphere(rightEnemyHand.position, 0.5f);

        HashSet<PlayerHealthManager> playerHealthManagerHashSet = new HashSet<PlayerHealthManager>();

        foreach (Collider nextTo in colliders)
        {
            PlayerHealthManager playerHealthManager = nextTo.GetComponentInParent<PlayerHealthManager>();

            if (playerHealthManager != null)
            {
                if (!playerHealthManagerHashSet.Contains(playerHealthManager))
                {
                    playerHealthManager.DamagePlayer(damageDoneToPlayer);
                    playerHealthManagerHashSet.Add(playerHealthManager);
                }
            }
        }
    }

    public void DamagePlayerByLeftHand()
    {
        Collider[] colliders = Physics.OverlapSphere(leftEnemyHand.position, 0.5f);

        HashSet<PlayerHealthManager> playerHealthManagerHashSet = new HashSet<PlayerHealthManager>();

        foreach (Collider nextTo in colliders)
        {
            PlayerHealthManager playerHealthManager = nextTo.GetComponentInParent<PlayerHealthManager>();

            if (playerHealthManager != null)
            {
                if (!playerHealthManagerHashSet.Contains(playerHealthManager))
                {
                    playerHealthManager.DamagePlayer(damageDoneToPlayer);
                    playerHealthManagerHashSet.Add(playerHealthManager);
                }
            }
        }
    }
}
