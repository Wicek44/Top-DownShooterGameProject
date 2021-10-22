using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmRocketController : MonoBehaviour
{
    [SerializeField] private Transform throwingWeaponGrip;
    [SerializeField] private GameObject napalmRocket;
    [SerializeField] private Camera mainCamera;

    private PlayerHealthManager playerHealthManager;
    private EnemySpawnManager enemySpawnManager;
    
    private bool isNapalmStrikePickedUp = false;

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (isNapalmStrikePickedUp == true)
                {
                    NapalmRocketDropAtMousePosition();
                    isNapalmStrikePickedUp = false;
                }
            }
        }
    }

    private void NapalmRocketDropAtMousePosition()
    {
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit; 

        if(Physics.Raycast(ray, out raycastHit))
        {
            Instantiate(napalmRocket, new Vector3(raycastHit.point.x, napalmRocket.transform.position.y, raycastHit.point.z), napalmRocket.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NapalmStrike")
        {
            isNapalmStrikePickedUp = true;
            Destroy(collision.gameObject);
        }
    }

}
