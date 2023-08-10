using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider hpSlider;
    public int maxWrongClicks = 3;

    public string winSceneName = "WinScene";
    public string gameOverSceneName = "GameOverScene";

    private int correctClicks = 0;
    private int wrongClicks = 0;

    private Scene GTTB_Stairs;
    private Scene GTTB_MagicBarracade;
    private Scene GTTB_PileofDebris;

    private void Start()
    {
        hpSlider.maxValue = maxWrongClicks;
        hpSlider.value = 0;

                                                                                                                                    // Get references to the scenes
        GTTB_Stairs = SceneManager.GetSceneByName("GTTB_Stairs");                           
        GTTB_MagicBarracade = SceneManager.GetSceneByName("GTTB_MagicBarracade");
        GTTB_PileofDebris = SceneManager.GetSceneByName("GTTB_PileofDebris");

        // Load the initial scene
        LoadRandomScene();
    }

    private void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, 3);
        Scene randomScene;

        switch (randomIndex)
        {
            case 0:
                randomScene = GTTB_Stairs;
                break;
            case 1:
                randomScene = GTTB_MagicBarracade;
                break;
            case 2:
                randomScene = GTTB_PileofDebris;
                break;
            default:
                randomScene = GTTB_Stairs;
                break;
        }

        SceneManager.LoadScene(randomScene.name);
    }

    public void WinConditionMet()
    {
        correctClicks++;

        if (correctClicks >= 10)
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            LoadRandomScene();
        }
    }

    public void LoseConditionMet()
    {
        wrongClicks++;
        hpSlider.value = wrongClicks;

        if (wrongClicks >= maxWrongClicks)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
        else
        {
            LoadRandomScene();
        }
    }
}
