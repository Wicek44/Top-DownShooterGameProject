using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    
    private PlayerHealthManager playerHealthManager;
    private EnemySpawnManager enemySpawnManager;
    
    private Vector3 velocity;

    public void Start()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
    }

    public void FixedUpdate()
    {
        if (playerHealthManager.playerDied == true || enemySpawnManager.IsLevelFinished == true)
        {
            return;
        }

        if(playerHealthManager.playerDied == false)
        {
            playerRigidBody.MovePosition(playerRigidBody.position + velocity * Time.deltaTime);
        }
    }

    public void PlayerMovement(Vector3 argVelocity)
    {
        velocity = argVelocity;
    }

    public void LookAt(Vector3 actualLookPoint)
    {
        if (playerHealthManager.playerDied == true)
        {
            return;
        }

        if (playerHealthManager.playerDied == false)
        {
            Vector3 correctedHeight = new Vector3(actualLookPoint.x, transform.position.y, actualLookPoint.z);
            transform.LookAt(correctedHeight);
        }

    }
}
