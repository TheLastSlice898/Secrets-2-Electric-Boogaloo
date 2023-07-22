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
    public GameObject PopUp_Do_It;
    public GameObject PopUp_Come_On;
    public GameObject PopUp_Ford_Fiesta;
    public GameObject PopUp_Please;



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
        StartCoroutine(PopUpActivate()); 
      
       
    }

    //thanks to scott for this one :3
    IEnumerator PopUpActivate()
    {
        //Debug.Log("mmmm started at 3 " + Time.time);
        // tells the code to wait for x amount 
        yield return new WaitForSeconds(3); 

        //then starts function
        togglePopUp1();

        yield return new WaitForSeconds(5);

        togglePopUp2(); 

        yield return new WaitForSeconds(5);

        togglePopUp3();

        yield return new WaitForSeconds(5);

        togglePopUp4();
        
        
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
        Debug.Log("You Lose");
        SceneManager.LoadScene("Button_Game");
    }



}

//Thank you and credits to Dani Krossing on Youtube for the tutorial on  "timer = GameObject.Find("Button_Base/Timer").GetComponent<Timer>();"
//https://www.youtube.com/watch?v=Y7pp2gzCzUI&ab_channel=DaniKrossing