using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettingsInfoController : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    void Start()
    {
        returnButton.onClick.AddListener(LoadMainMenuScene);
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE);
    }
}
