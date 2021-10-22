using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button floodedDistrictLevelButton;
    [SerializeField] private Button desertFortLevelButton;
    [SerializeField] private Button forestVillageLevelButton;
    [SerializeField] private Button returnButton; 
    

    private void Awake()
    {
        floodedDistrictLevelButton.onClick.AddListener(LoadFloodedDistrictScene);
        desertFortLevelButton.onClick.AddListener(LoadDesertFortScene);
        forestVillageLevelButton.onClick.AddListener(LoadForestVillageScene);
        returnButton.onClick.AddListener(LoadMainMenuScene);
    }

    void Start()
    {
        PlayerPrefs.GetInt(SceneNames.FLOODED_DISTRICT_SCENE);
        PlayerPrefs.GetInt(SceneNames.DESERT_FORT_SCENE);
        PlayerPrefs.GetInt(SceneNames.FOREST_VILLAGE_SCENE);


        if (PlayerPrefs.GetInt(SceneNames.FLOODED_DISTRICT_SCENE) == 1)
        {
            desertFortLevelButton.interactable = true;
        }
        else
        {
            desertFortLevelButton.interactable = false;
        }

        if (PlayerPrefs.GetInt(SceneNames.DESERT_FORT_SCENE) == 1)
        {
            forestVillageLevelButton.interactable = true;
        }
        else
        {
            forestVillageLevelButton.interactable = false;
        }
    }

   

    private void LoadFloodedDistrictScene()
    {
        SceneManager.LoadScene(SceneNames.FLOODED_DISTRICT_SCENE);
    }

    private void LoadDesertFortScene()
    {
        SceneManager.LoadScene(SceneNames.DESERT_FORT_SCENE);
    }

    private void LoadForestVillageScene()
    {
        SceneManager.LoadScene(SceneNames.FOREST_VILLAGE_SCENE);
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE);
    }
}
