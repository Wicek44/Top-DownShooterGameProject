using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveInfoPanelController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI waveCounter;
    [SerializeField] private TextMeshProUGUI enemiesCounter;

    private EnemySpawnManager enemySpawnManager;
    
    void Start()
    {
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
        enemySpawnManager.OnStartNewWave += AnimateAndUpdateWaveInfoPanel;
    }
    
    private void AnimateAndUpdateWaveInfoPanel()
    {
        animator.SetTrigger("NewWaveTrigger");

        waveCounter.text = enemySpawnManager.currentWaveNumber.ToString();
        enemiesCounter.text = enemySpawnManager.enemiesWaitngToSpawn.ToString();
    }
}
