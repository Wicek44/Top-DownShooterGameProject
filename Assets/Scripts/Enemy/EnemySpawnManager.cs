using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float intervalBetweenSpawns;
    }

    public Wave[] waves;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] GameController gameController; // czy to jest potrzebne?! 
    [SerializeField] private RectTransform waveInfoPanel;
    [SerializeField] private WaveInfoPanelController waveInfoPanelController;

    public Wave currentWave { get; private set; }
    public int currentWaveNumber { get; private set; }
    private int timeBetweenWaves = 5;

    public int enemiesWaitngToSpawn { get; private set; }
    private int enemiesRemainingAlive = 0;

    public Action OnWaveActive;
    public Action OnLastWaveFinished;
    private bool wasLastWaveEventInvoked;

    public bool IsLevelFinished { get; private set; } = false;
    public event Action OnClearAllWaves;
    public event Action OnStartNewWave;


    void Update()
    {
        if (IsLevelFinished == false)
        {
            if (currentWaveNumber == 5 && enemiesRemainingAlive <= 0) 
            {
                IsLevelFinished = true;
                OnClearAllWaves?.Invoke();
            }
        }

        if (enemiesRemainingAlive == 0)
        {
            StartNextWave();
            OnStartNewWave?.Invoke();
        }
    }

    void StartNextWave()
    {

        if (currentWaveNumber >= waves.Length)
        {
            if (wasLastWaveEventInvoked == false)
            {
                wasLastWaveEventInvoked = true;
                OnLastWaveFinished?.Invoke();
            }

            return;
        }

        OnWaveActive?.Invoke();
        currentWaveNumber++;

        currentWave = waves[currentWaveNumber - 1];
        enemiesWaitngToSpawn = currentWave.enemyCount;

        enemiesRemainingAlive = enemiesWaitngToSpawn;
       
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        for (int i = 0; i < enemiesWaitngToSpawn; i++)
        {
            Collider[] colliders;
            Vector3 spawnPosition;
            var randomX = UnityEngine.Random.Range(-7f, 7f);
            var randomZ = UnityEngine.Random.Range(-7f, 7f);

            do
            {
                spawnPosition = new Vector3(randomX, 1f, randomZ);
                colliders = Physics.OverlapBox(spawnPosition, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, LayerMask.NameToLayer("Enviroment"));
               
            } while (colliders.Length != 0);

            var enemySpawned = Instantiate(enemyPrefab, spawnPosition, new Quaternion(0, 0, 0, 0));
           
            enemySpawned.GetComponent<EnemyHeatlhManager>().OnDied += CountDeadEnemies;
            yield return new WaitForSeconds(currentWave.intervalBetweenSpawns);
        }
    }

    void CountDeadEnemies()
    {
        enemiesRemainingAlive--;
    }
}
