using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Button_Time : MonoBehaviour
{
    internal static float deltaTime;
    public bool timeOn;
    public float timeThatsLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            if (timeThatsLeft > 0)
            {
                timeThatsLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("you lose");
                timeThatsLeft = 0;
                timeOn = false;
                SceneManager.LoadScene("Button_Game");

            }
        }
    }


}