using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemySpawnManager enemySpawnManager;
    [SerializeField] private PlayerHealthManager playerHealthManager;

    void Start()
    {
        enemySpawnManager.OnClearAllWaves += LevelCompleted;
        playerHealthManager.OnPlayerGetKilled += LevelFailed;
    }

    private void LevelCompleted()
    {
        SceneManager.LoadScene(SceneNames.LEVEL_COMPLETED_SCENE, LoadSceneMode.Additive);
        Cursor.visible = true;
    }

    private void LevelFailed()
    {
        SceneManager.LoadScene(SceneNames.GAME_OVER_SCENE, LoadSceneMode.Additive);
        Cursor.visible = true;
    }
}
