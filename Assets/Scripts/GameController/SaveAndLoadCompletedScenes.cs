using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoadCompletedScenes : MonoBehaviour
{
    [SerializeField] private EnemySpawnManager enemySpawnManager;

    void Start()
    {
        enemySpawnManager.OnClearAllWaves += GetCurrentSceneNameAndSaveAsCompleted;
    }

    private void GetCurrentSceneNameAndSaveAsCompleted()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
    }

}
