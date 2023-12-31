using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockScript : MonoBehaviour
{
    public Button Catch; 
    public Button Repair;
    public Button Puzzle;
    public Button Dungeon;
    public Button Pursuit;
    public Button Potion;
    public Button LockPicking;
    public Button Boss;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("CatchInt") == 1)
        {
            Catch.interactable = true;
        }
        if (PlayerPrefs.GetInt("RepairInt") == 1)
        {
            Repair.interactable = true;
        }
        if (PlayerPrefs.GetInt("ButtonInt") == 1)
        {
            Puzzle.interactable = true;
        }
        if (PlayerPrefs.GetInt("DungeonInt") == 1)
        {
            Dungeon.interactable = true;
        }
        if (PlayerPrefs.GetInt("PursuitInt") == 1)
        {
            Pursuit.interactable = true;
        }
        if (PlayerPrefs.GetInt("PotionInt") == 1)
        {
            Potion.interactable = true;
        }
        if (PlayerPrefs.GetInt("ToTheBossInt") == 1)
        {
            LockPicking.interactable = true;
        }
        if (PlayerPrefs.GetInt("BossInt") == 1)
        {
            Boss.interactable = true;
        }

    }
}
