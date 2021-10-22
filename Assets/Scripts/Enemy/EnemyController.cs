using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigidBody;
    [SerializeField] private PlayerController player;
    [SerializeField] private float enemyMovementSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    private EnemyHeatlhManager enemyHeatlhManager;
    private PlayerHealthManager playerHealthManager;

    public bool iSAnimatorAndNavMeshAgentStopped { get; private set; } = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>(); 
        enemyHeatlhManager = GetComponent<EnemyHeatlhManager>();
    }


    private void FixedUpdate()
    {
        if(player.GetComponent<PlayerHealthManager>().playerDied == true)
        {
            if (iSAnimatorAndNavMeshAgentStopped == false)
            {
                iSAnimatorAndNavMeshAgentStopped = true;
                animator.enabled = false;
                navMeshAgent.enabled = false;
            }
            return;
        }

        if(player.GetComponent<PlayerHealthManager>().playerDied == false) 
        {
            if (enemyHeatlhManager.enemyDied == true)
            {
                return;
            }

            if (enemyHeatlhManager.enemyDied == false)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
        }
    }

    void Update()
    {
        if(enemyHeatlhManager.enemyDied == true)
        { 
            return; 
        }

        if( enemyHeatlhManager.enemyDied == false)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

            foreach (Collider nextTo in colliders)
            {
                PlayerHealthManager playerHealthManager = nextTo.GetComponentInParent<PlayerHealthManager>();

                if (playerHealthManager != null)
                {
                    animator.SetTrigger("Attack");
                }
            }
        }  
    }
}
