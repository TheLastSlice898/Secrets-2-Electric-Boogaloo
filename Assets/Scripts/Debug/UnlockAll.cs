using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedAll : MonoBehaviour
{
    // Start is called before the first frame update
    public void Debug()
    {
        PlayerPrefs.SetInt("CatchInt", 1);
        PlayerPrefs.SetInt("RepairInt", 1);
        PlayerPrefs.SetInt("PuzzleInt", 1);
        PlayerPrefs.SetInt("TreeTopsInt", 1);
        PlayerPrefs.SetInt("PursuitInt", 1);
        PlayerPrefs.SetInt("PotionInt", 1);
        PlayerPrefs.SetInt("LockpickInt", 1);
        PlayerPrefs.SetInt("BossInt", 1);
    }

}