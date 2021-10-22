using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    [SerializeField] private int initialPlayerHealth;
    [SerializeField] private DamagePopupController damagePopupPrefab;
    [SerializeField] private GameObject damagePopupMarker;
    [SerializeField] private Animator animator;
    [SerializeField] GameController gameController; 

    private int currentPlayerHealth;
    public bool playerDied { get; private set; } = false;
    public event Action OnPlayerGetKilled;  

    //public float flashDuration;
    //private float flashCounter;

    //private Renderer colorRenderer;
    //private Color playerColor;


    void Start()
    {
        currentPlayerHealth = initialPlayerHealth;
        playerDied = false;
        //colorRenderer = GetComponent<Renderer>();
        //playerColor = colorRenderer.material.GetColor("_Color");
    }

    private void Update()
    {
        if(playerDied == false)
        {
            if (currentPlayerHealth <= 0)
            {
                animator.SetTrigger("Death");
                playerDied = true;
                OnPlayerGetKilled?.Invoke();
            }
        }

        /*if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {
                colorRenderer.material.SetColor("_Color", playerColor);
            }
        }*/
    }

    public void DamagePlayer(int damage)
    {
        DamagePopupController damagePopup = Instantiate(damagePopupPrefab, damagePopupMarker.transform.position, damagePopupPrefab.transform.rotation, damagePopupMarker.transform);
        damagePopup.SetDamageText(damage);

        currentPlayerHealth -= damage;
        //flashCounter = flashDuration;
        //colorRenderer.material.SetColor("_Color", Color.red);
    }
}
