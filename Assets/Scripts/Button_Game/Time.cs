using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Time : MonoBehaviour
{
    internal static float deltaTime;
    public bool timerOn;
    public float timeLeft;
    void Start()
    {
        timerOn = true;
    }

    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("you lose");
                timeLeft = 0;
                timerOn = false;
                SceneManager.LoadScene("Button_Game");

            }
        }
    }
}
