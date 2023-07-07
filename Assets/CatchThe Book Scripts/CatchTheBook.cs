using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class CatchTheBook : MonoBehaviour
{
    public TextMeshProUGUI healthBox;
    int bookHealth; 

    public float secondCounter; 
    public float FlyTime; 
    public bool BookIsFlying;

    public bool BookOnLeft;
    public bool BookOnRight;

    public TextMeshProUGUI timeBox; 
    public float loseTimer; 

    // Start is called before the first frame update
    void Start()
    {
        bookHealth = 3; 
        healthBox.text = "Book HP: " + bookHealth; 
        
        BookOnLeft = true; 
        BookOnRight = false; 
        transform.position = new Vector3(-5.67f, 0.87f, -7.72f); 

        secondCounter = 0.0f;
        BookIsFlying = false; 

        loseTimer = 30f; 
        timeBox.text = "Time Remaining: " + loseTimer; 

        RandomiseFlyTime(); 
    }

    // Update is called once per frame
    void Update()
    {
        secondCounter += Time.deltaTime; 
        loseTimer -= Time.deltaTime; 
        //Debug.Log(secondCounter);
        //Debug.Log(FlyTime); 
        timeBox.text = "Time Remaining: " + (int)loseTimer; 

        if(secondCounter >= FlyTime && BookIsFlying == false) {
            BookIsFlying = true;
            //Debug.Log("Fly you fool"); 
        }

        if(Input.GetKeyDown("space") && BookIsFlying == true) {
            bookHealth -= 1; 
            healthBox.text = "Book HP: " + bookHealth; 
             
            secondCounter = 0f; 
            FlyTime = 100f; 

            if(BookOnLeft == true) { 
                MoveBookRight();
                } 
                else {
                     MoveBookLeft();
                    }

            RandomiseFlyTime(); 
            BookIsFlying = false;
        }

        if(BookIsFlying == true && BookOnLeft == true) {
            transform.position += new Vector3(0,0,20) * Time.deltaTime;
        }

        if(BookIsFlying == true && BookOnRight == true) {
            transform.position += new Vector3(0,0,-20) * Time.deltaTime;
        }

        if(loseTimer <= 0f) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    public void RandomiseFlyTime()
    {
        FlyTime = Random.Range(1,10); 
    }

    public void MoveBookRight()
    {
        //Debug.Log("Amogus");
        BookOnRight = true; 
        BookOnLeft = false;
        transform.position = new Vector3(-5.67f, 0.87f, 7.72f);
    }

    public void MoveBookLeft()
    {
        //Debug.Log("Sussy");
        BookOnRight = false; 
        BookOnLeft = true; 
        transform.position = new Vector3(-5.67f, 0.87f, -7.72f); 
    }
}
