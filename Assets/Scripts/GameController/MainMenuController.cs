using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsInfoButton;
    [SerializeField] private Button quitGameButton;

    void Start()
    {
        startGameButton.onClick.AddListener(LoadLevelSelectionScene);
        settingsInfoButton.onClick.AddListener(LoadSettingsInfoScene);
        quitGameButton.onClick.AddListener(ExitGame);
    }

    
    private void LoadLevelSelectionScene()
    {
        SceneManager.LoadScene(SceneNames.LEVEL_SELECTION_SCENE);
    }


    private void LoadSettingsInfoScene()
    {
        SceneManager.LoadScene(SceneNames.SETTINGS_INFO_SCENE);
    }

    private void ExitGame()
    {

        Application.Quit();
    }
}
