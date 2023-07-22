using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    //SceneName of the current Scene
    public string SceneName;
    public int SceneInt;
    public bool Debug;
    public bool PauseMenu;
    public GameObject PauseMenuOBJ;
    //unlock varaibles for the minigames
    public bool UnlockedCatch;
    public bool UnlockedRepair;
    public bool UnlockedPuzzle;
    public bool UnlockedTreeTops;
    public bool UnlockedPursuit;
    public bool UnlockedPotion;
    public bool UnlockedLockPicking;
    public bool UnlockedBoss;

    //this makes the game manager a EventBus
    private static GameManage _GameManager;
    public static GameManage GameManager { get { return _GameManager; } }

    //this makes it that only one of this object can be in the same scene
    private void Awake()
    {
        if (_GameManager != null && _GameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _GameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //instances all the player Prefrences 
        PlayerPrefs.SetInt("CatchInt", (UnlockedCatch ? 1 : 0));
        PlayerPrefs.SetInt("RepairInt", (UnlockedRepair ? 1 : 0));
        PlayerPrefs.SetInt("PuzzleInt", (UnlockedPuzzle ? 1 : 0));
        PlayerPrefs.SetInt("TreeTopsInt", (UnlockedTreeTops ? 1 : 0));
        PlayerPrefs.SetInt("PursuitInt", (UnlockedPursuit ? 1 : 0));
        PlayerPrefs.SetInt("PotionInt", (UnlockedPotion ? 1 : 0));
        PlayerPrefs.SetInt("LockpickInt", (UnlockedLockPicking ? 1 : 0));
        PlayerPrefs.SetInt("BossInt", (UnlockedBoss ? 1 : 0));
    }

    // Update is called once per frame
    void Update()
    {
        //checks what the active scene for the gamemanaager
        WhatSceneAmI();
        //sets the bool to the Variable of the playerPrefs for debuging 
        if (PauseMenu)
        {
            PauseMenuOBJ.SetActive(true);
        }
        else
        {
            PauseMenuOBJ.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //was gonna make a escape button for pause but cba at 1am TWT
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneName);

    }

    public void WhatSceneAmI()
    {
        Scene MyScene = SceneManager.GetActiveScene();
        SceneInt = MyScene.buildIndex;
        SceneName = MyScene.name;
    }
    public void StartScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        PauseMenu = true;
        if (Debug)
        {
            SceneManager.LoadScene("Debug", LoadSceneMode.Additive);
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        PauseMenu = false;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneInt + 1, LoadSceneMode.Single);
        PauseMenu = true;
        if (Debug)
        {
            SceneManager.LoadScene("Debug", LoadSceneMode.Additive);
        }
        
    }
    public void PauseMenuStart()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
    public void PauseMenuEnd()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }
    public void LoadLevels()
    {
        SceneManager.LoadScene("Levels", LoadSceneMode.Additive);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }
    public void CheckLevels()
    {
        UnlockedCatch = (PlayerPrefs.GetInt("CatchInt") != 0);
        UnlockedRepair = (PlayerPrefs.GetInt("RepairInt") != 0);
        UnlockedPuzzle = (PlayerPrefs.GetInt("PuzzleInt") != 0);
        UnlockedTreeTops = (PlayerPrefs.GetInt("TreeTopsInt") != 0);
        UnlockedPursuit = (PlayerPrefs.GetInt("PursuitInt") != 0);
        UnlockedPotion = (PlayerPrefs.GetInt("PotionInt") != 0);
        UnlockedLockPicking = (PlayerPrefs.GetInt("LockpickInt") != 0);
        UnlockedBoss = (PlayerPrefs.GetInt("BossInt") != 0);
    }
}
