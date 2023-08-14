using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press : MonoBehaviour
{
    Timer timer;

    public GameObject button;
    public GameObject time;


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
    }


    private void OnMouseDown()
    {
        isPressed = true;
    }


    private void OnMouseUp() 
    {
        Debug.Log("you win");
        GameManage.GameManager.WinScreen();
        
    }
}


//Thank you and credits to Dani Krossing on Youtube for the tutorial on  "timer = GameObject.Find("Button_Base/Timer").GetComponent<Timer>();"
//https://www.youtube.com/watch?v=Y7pp2gzCzUI&ab_channel=DaniKrossing
