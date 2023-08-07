using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CardRight;
    public GameObject CardLeft;
    public GameObject timer; 
    public int CardTotal = 0; 
    void OnDestroy()
    {
        //Debug.Log("Bye");
    }
    void ToggleLeft()
    {
        CardLeft.SetActive(true);
        
    }

    void ToggleRight()
    {
        CardRight.SetActive(true);

    }

    //On trigger enter means when the colliders then it will do something 
    // that something is if the gameobject is tagged as "LEFT" or "RIGHT" then it will destrig the dragged object, and toggle the hidden static page
    // the static page acts like a "drag and lock", so player are unable to move it once placed 
    public void OnTriggerEnter(Collider other)
    {

        //Debug.Log("aaaaaaaaaa");
        if (other.gameObject.CompareTag("Left"))
        {
            Debug.Log("Im the left");
            Destroy(other.gameObject);
            ToggleLeft();
            CountCard();
        }
        if (other.gameObject.CompareTag("Right"))
        {
            Debug.Log("Im the right");
            Destroy(other.gameObject);
            ToggleRight();
            CountCard(); 
        }


        
    }

    public void CountCard () 
    { 
        CardTotal = CardTotal + 1;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(CardTotal == 6) 
        {
            GameManage.GameManager.WinScreen();
            //Debug.Log("op");
            timer.GetComponent<Timer>().timerOn = false;
            
        }
    }


  }

