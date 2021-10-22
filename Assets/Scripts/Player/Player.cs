using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private Animator animator;

    private PlayerHealthManager playerHealthManager;
    private EnemySpawnManager enemySpawnManager;
    private PauseMenuController pauseMenuController;

    private Camera mainCamera;
    public Transform crosshair;
    public float playerMoveSpeed = 5; 

    public void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        playerHealthManager = GetComponent<PlayerHealthManager>();
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
        pauseMenuController = FindObjectOfType<PauseMenuController>();
    }

    public void Update()
    {
        if (playerHealthManager.playerDied == true || enemySpawnManager.IsLevelFinished == true || pauseMenuController.isGamePaused == true)
        {
            return;
        }

        if (playerHealthManager.playerDied == false)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            animator.SetFloat("X", x);
            animator.SetFloat("Z", z);

            Vector3 movePlayerInput = new Vector3(x, 0, z);
            Vector3 moveVelocity = movePlayerInput.normalized * playerMoveSpeed;
            playerController.PlayerMovement(moveVelocity);

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                playerController.LookAt(point);
                crosshair.position = Camera.main.WorldToScreenPoint(point);
            }

            if (Input.GetMouseButton(0))
            {
                weaponController.ShootWeapon();
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Shoot", true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("Shoot", false);
            }
        }
    }
}
