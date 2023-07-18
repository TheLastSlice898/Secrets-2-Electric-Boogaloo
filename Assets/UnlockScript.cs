using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockScript : MonoBehaviour
{
    public GameObject GameMang;

    public Button Catch;
    public Button Repair;
    public Button Puzzle;
    public Button TreeTops;
    public Button Pursuit;
    public Button Potion;
    public Button LockPicking;
    public Button Boss;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.UnlockedCatch == true)
       {
           Catch.interactable = true;
       }
    }
}
