using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press : MonoBehaviour
{
    Timer timer;

    public GameObject button;
    public GameObject time;
    public GameObject PopUp_Please;
    public GameObject PopUp_Ford_Fiesta;
    public GameObject PopUp_Come_On;
    public GameObject PopUp_Do_It;

    private bool isPressed;

    // Awake is called before start, it "wakes up"
    private void Awake()
    {

        //finds what the script is on and grabs it 
        timer = GameObject.Find("Button_Base/Timer").GetComponent<Timer>();

    }




    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;

        if (timer.timeLeft > 15)
        {
            togglePopUp1();
        }
        else if (timer.timeLeft == 12)
       {
            togglePopUp2();
       }

        else if (timer.timeLeft == 7) 
        { 
            togglePopUp3();
        }

        else if(timer.timeLeft == 2)
        {
            togglePopUp4();
        }
       
    }

    void togglePopUp1()

    {
        PopUp_Do_It.SetActive(true);
    }

    void togglePopUp2()

    {
        PopUp_Come_On.SetActive(true);
    }

    void togglePopUp3()

    {
        PopUp_Ford_Fiesta.SetActive(true);
    }

    void togglePopUp4()

    {
        PopUp_Please.SetActive(true);
    }
    public void OnMouseDown()
    {
        //Debug.Log("this is clickable");
        isPressed = true;
    }

    public void OnMouseUp() 
    {
        Debug.Log("Lose");
        SceneManager.LoadScene("Button_Game");
    }



}

//Thank you and credits to Dani Krossing on Youtube for the tutorial on  "timer = GameObject.Find("Button_Base/Timer").GetComponent<Timer>();"
//https://www.youtube.com/watch?v=Y7pp2gzCzUI&ab_channel=DaniKrossing

