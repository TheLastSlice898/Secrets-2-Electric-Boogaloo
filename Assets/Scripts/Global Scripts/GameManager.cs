using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    //SceneName of the current Scene
    public string SceneName;
    public string[] SceneOrder;
    public int SceneInt;
    public bool bookbool;
    public bool Debug;
    public bool PauseMenu;
    public GameObject DebugOBJ;
    public GameObject PauseMenuOBJ;
    public GameObject BookOBJ;
    //unlock varaibles for the minigames
    
    public bool UnlockedCatch;
    public bool UnlockedRepair;
    public bool UnlockedButton;
    public bool UnlockedDungeon;
    public bool UnlockedPursuit;
    public bool UnlockedPotion;
    public bool UnlockedToTheTop;
    public bool UnlockedBoss;


    // Start is called before the first frame update
    //turns the bool between on and off everytime the button is clicked

    //sets the book active according to the bool
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
        PlayerPrefs.SetInt("ButtonInt", (UnlockedButton ? 1 : 0));
        PlayerPrefs.SetInt("DungeonInt", (UnlockedDungeon ? 1 : 0));
        PlayerPrefs.SetInt("PursuitInt", (UnlockedPursuit ? 1 : 0));
        PlayerPrefs.SetInt("PotionInt", (UnlockedPotion ? 1 : 0));
        PlayerPrefs.SetInt("ToTheBossInt", (UnlockedToTheTop ? 1 : 0));
        PlayerPrefs.SetInt("BossInt", (UnlockedBoss ? 1 : 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug)
        {
            DebugOBJ.SetActive(Debug);
        }
        else
        {
            DebugOBJ.SetActive(Debug);
        }
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
        BookOBJ.SetActive(bookbool);

        if (bookbool)
        {
            Time.timeScale = 0;
        }
        else
        {

        }
    }
    public void BookFunction()
    {
        if (bookbool)
        {
            bookbool = false;
        }
        else
        {
            bookbool = true;
        }
    }

    public void WinScreen()
    {
        SceneInt++;
        gameObject.GetComponent<Achivement_System>().UnlockedLevel();
        SceneManager.LoadScene("You_Won");
        Time.timeScale = 0;
    }
    public void LoseScreen()
    {
        SceneManager.LoadScene("Game_Over");
        Time.timeScale = 0;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneOrder[SceneInt]);
        Time.timeScale = 1;
    }

    public void WhatSceneAmI()
    {
        Scene MyScene = SceneManager.GetActiveScene();
        SceneName = MyScene.name;
    }
    public void StartScene()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Single);
        PauseMenu = true;
        
        
        //if (Debug)
        //{
        //    SceneManager.LoadScene("Debug", LoadSceneMode.Additive);
        //}

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        PauseMenu = false;
        bookbool = false;
        Time.timeScale = 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneOrder[SceneInt], LoadSceneMode.Single);
        PauseMenu = true;
        Time.timeScale = 1;

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
        UnlockedButton = (PlayerPrefs.GetInt("ButtonInt") != 0);
        UnlockedDungeon = (PlayerPrefs.GetInt("DungeonInt") != 0);
        UnlockedPursuit = (PlayerPrefs.GetInt("PursuitInt") != 0);
        UnlockedPotion = (PlayerPrefs.GetInt("PotionInt") != 0);
        UnlockedToTheTop = (PlayerPrefs.GetInt("ToTheBossInt") != 0);
        UnlockedBoss = (PlayerPrefs.GetInt("BossInt") != 0);
    }
}
