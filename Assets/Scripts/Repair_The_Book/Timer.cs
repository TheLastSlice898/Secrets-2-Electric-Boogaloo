using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    internal static float deltaTime;
    public bool timerOn;
    public float timeLeft;
   

   

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true; 
        
    }

// Update is called once per frame
void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                GameManage.GameManager.LoseScreen();
                timeLeft = 0;
                timerOn = false;

            }
        }
    }


}
