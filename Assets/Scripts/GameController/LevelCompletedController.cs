using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletedController : MonoBehaviour
{
    [SerializeField] private Button levelSelectionButton;

    private void Awake()
    {
        levelSelectionButton.onClick.AddListener(LoadLevelSelectionScene);
    }

    private void LoadLevelSelectionScene()
    {
        SceneManager.LoadScene(SceneNames.LEVEL_SELECTION_SCENE);
    }
}
