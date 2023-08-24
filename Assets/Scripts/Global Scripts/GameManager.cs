using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    
    public string SceneName;        //SceneName of the current Scene
    public string[] SceneOrder;     //States the order of the scenes in a array        
    public AudioClip[] MusicClips;
    public int SceneInt;            //a int represetning the current buildscene
    public bool bookbool;               //a bool to check if the instrcution book is active 
    public bool Debug;              //bool for debug menu for testing
    public bool PauseMenu;          //book for if the pause menu can be seen
    public GameObject DebugOBJ;         //the debug canvas
    public GameObject PauseMenuOBJ;         //the Pause Menu canvas
    public GameObject BookInstructions;         //the Instruction canvas
    public Image BookSprite;         //the image of the book that opens when you open the instruction menu
    //unlock varaibles for the minigames
    //in a bool
    public bool UnlockedCatch;
    public bool UnlockedRepair;
    public bool UnlockedButton;
    public bool UnlockedDungeon;
    public bool UnlockedPursuit;
    public bool UnlockedPotion;
    public bool UnlockedToTheTop;
    public bool UnlockedBoss;

    public AudioMixer MasterAudio;
    //This is the event bus and enables me to access this script from anywhere
    //This also states that if their is another one of this script in the scene delete the obj
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
        SceneName = SceneManager.GetActiveScene().name;
        GameManage.GameManager.GetComponent<Music_Syste3m>().MusicPlay();
    }

    void Start()
    {
        //instances all the player Prefrences at the start of the game
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
        //if the debug bool is active turn the menu on and off
        if (Debug)
        {
            DebugOBJ.SetActive(Debug);
        }
        else
        {
            DebugOBJ.SetActive(Debug);
        }


        //see line 139 for function info



        //if the pausemenu bool is active turn the menu on and off 
        if (PauseMenu)
        {
            PauseMenuOBJ.SetActive(true);
        }
        else
        {
            PauseMenuOBJ.SetActive(false);
        }

        //might be something in the future idk
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //was gonna make a escape button for pause but cba at 1am TWT
        }
        //sets the book active if the bool is active. 
        BookInstructions.SetActive(bookbool);

        //changes the sprite according to the bool
        if (bookbool)
        {
            //changes the sprite from the book inscruction array
            BookSprite.sprite = BookInstructions.GetComponent<Instructions>().BookStates[1];
            //sets time to 0 when the bool is active
            Time.timeScale = 0;
        }
        else
        {
            //changes the sprite from the book inscruction array
            BookSprite.sprite = BookInstructions.GetComponent<Instructions>().BookStates[0];
        }
    }
    //basic unary negation
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
    //win function for winning
    public void WinScreen()
    {
        
        SceneInt++;     //increases the scene int each time the player finishes a level
        PauseMenu = false;      //makes the pause menu disappear
        gameObject.GetComponent<Achivement_System>().UnlockedLevel();       //checks the name of the scene and then unlocks the level later
        SceneManager.LoadScene("You_Won"); //load the win scene
        Time.timeScale = 0; //time = 0 //ZA WARLDO
    }
    public void LoseScreen()
    {
        PauseMenu = false; //fuck off wodah
        SceneManager.LoadScene("Game_Over"); //activates the funny "L" scene
        Time.timeScale = 0; //yea you get the drill
    }

    public void ResetScene()
    {
        Scene TheScene = SceneManager.GetSceneByName(SceneOrder[SceneInt]);
        print(SceneInt);
        SceneManager.LoadScene(SceneOrder[SceneInt]);                                   //loads the scene of the current int but for somereaons doesnet work idfk
        Time.timeScale = 1; //time go zooooooooooooooooooom
    }
    //checks what the active scene for the Game Manager and sets the code for it
    public void WhatSceneAmI()
    {
        Scene MyScene = SceneManager.GetSceneByName(SceneOrder[SceneInt]); //get scene name 
        SceneName = MyScene.name; //WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,WHAT's MY NAME,
    }
    public void StartScene()
    {
        PauseMenu = true; //yes
        SceneName = SceneOrder[0];
        SceneManager.LoadScene(1, LoadSceneMode.Single); //load the first scene
        


        //if (Debug)
        //{
        //    SceneManager.LoadScene("Debug", LoadSceneMode.Additive);
        //}

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        SceneName = "Menu";
        PauseMenu = false;
        bookbool = false;
        Time.timeScale = 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneOrder[SceneInt], LoadSceneMode.Single);
        print(SceneInt);
        WhatSceneAmI();
        PauseMenu = true;
        Time.timeScale = 1;

    }
    public void PauseMenuStart()
    {
        //loads pause menu
        Time.timeScale = 0; //stop hammer time
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
    public void PauseMenuEnd()
    {
        //unload pause menu
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1; //NOT GONNA CATCH ME ALIVE. IM THE GINGER BREAD MAN
    }
    public void LoadLevels()
    {
        //loads levels scene
        SceneManager.LoadScene("Levels", LoadSceneMode.Additive);
    }
    public void LoadCredits()
    {
        //loads credits scene
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }
    public void CheckLevels()
    {
        //checks all the player prefs and sets the bools accordingly
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
