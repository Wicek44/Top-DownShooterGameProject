using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHeatlhManager : MonoBehaviour
{
    
    [SerializeField] private DamagePopupController damagePopupPrefab;
    [SerializeField] private GameObject damagePopupMarker;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody enemyRigidbody;
    private NavMeshAgent navMeshAgent;
    public bool enemyDied { get; private set; }
    public int enemyHealth;
    private int currentEnemyHealth;
    public Action OnDied;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentEnemyHealth = enemyHealth;
        enemyDied = false;
    }


    public void DamageEnemy(int damage)
    {
        DamagePopupController damagePopup = Instantiate(damagePopupPrefab, damagePopupMarker.transform.position, damagePopupPrefab.transform.rotation, damagePopupMarker.transform);
        damagePopup.SetDamageText(damage);

        currentEnemyHealth -= damage;

        if (currentEnemyHealth <= 0)
        {
            OnDied?.Invoke();
            animator.SetTrigger("Death");
            Destroy(enemyRigidbody);
            enemyDied = true;
            TurnOffAnimator();
        }
    }


    private void TurnOffAnimator()
    {
        navMeshAgent.enabled = false;
        StartCoroutine(MoveEnemyBodyUnderGroundCorutine());
    }

    private IEnumerator MoveEnemyBodyUnderGroundCorutine()
    {
        yield return new WaitForSeconds(2);
        animator.enabled = false;

        while (true)
        {
            var oldPosition = transform.position;
            transform.position = new Vector3(oldPosition.x, oldPosition.y - 0.1f * Time.deltaTime, oldPosition.z);

            yield return null;

            if (transform.position.y <= -5)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
