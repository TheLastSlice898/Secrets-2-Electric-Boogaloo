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
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneInt+1, LoadSceneMode.Single);
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
    }
    
    public void LoadLevels()
    {
        SceneManager.LoadScene(7, LoadSceneMode.Additive);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
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
