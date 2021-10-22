using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitGameButton;

    public bool isGamePaused { get; private set; }  = false;

    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(ReloadCurrentScene);
        mainMenuButton.onClick.AddListener(LoadMainMenuScene);
        quitGameButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        isGamePaused = false;
    }

    private void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        isGamePaused = true;
    }

    private void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE);
    }

    private void ExitGame()
    {

        Application.Quit();
    }

}
