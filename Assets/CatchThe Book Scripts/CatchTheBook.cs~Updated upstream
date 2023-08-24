using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class CatchTheBook : MonoBehaviour
{
    public TextMeshProUGUI healthBox;
    public int bookHealth; 
    //variable for the health of the book, which relates to our win condition, as well as a UI element link so we can display it to the player

    public float secondCounter; //keeps track of the number of seconds that has passed. Resets upon certain conditions
    public int FlyTime; //A variable to hold the random time that the book will fly
    public bool BookIsFlying; //a bool so we can check whether or not the book is currently flying

    public bool BookOnLeft; //let's us check that the book is on the left
    public bool BookOnRight; //let's us check that the book is on the right 

    public TextMeshProUGUI timeBox; 
    public float loseTimer; 
    //a seperate, overall timer that does not reset, tied to the lose condition 

    public GameObject leftBookshelf; 
    public GameObject rightBookshelf; 
    public int rumbleTime; 
    public bool canRumble; 

    public GameObject BookHealth1; 
    public GameObject BookHealth2; 
    
    public AudioSource BookSoundSource; 
    public AudioClip BookMusic; 
    public AudioClip BookDamage; 
    public AudioClip ShelfRumble; 

    // Start is called before the first frame update
    void Start()
    {
        bookHealth = 3; 
        //healthBox.text = "Book HP: " + bookHealth; 
        //Ensures the Book's health is reset when the scene loads, as well as updating the UI
        
        BookOnLeft = true; 
        BookOnRight = false; 
        transform.position = new Vector3(-5.5f, 0.87f, -7.2f); 
        //resets the book's position to the left, sets variables to reflect this

        secondCounter = 0.0f;
        BookIsFlying = false; 
        //resets more variables

        loseTimer = 30f; 
        timeBox.text = "Time Remaining: " + loseTimer; 
        //resets the lose timer

        RandomiseFlyTime(); 
        //triggers the function to randomise the time that the book flies 

        BookHealth1.SetActive(false); 
        BookHealth2.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        secondCounter += Time.deltaTime; 
        loseTimer -= Time.deltaTime; 
        //Debug.Log(secondCounter);
        //Debug.Log(FlyTime); 
        timeBox.text = "Time Remaining: " + (int)loseTimer; 
        //increases the secondCounter while decreasing the loseTimer

        if(secondCounter >= FlyTime && BookIsFlying == false) {
            BookIsFlying = true;
            //Debug.Log("Fly you fool"); 
        }
        //sets the variable to allow the player to catch the book

        if(secondCounter >= rumbleTime && FlyTime >= 7 && BookIsFlying == false && canRumble == true && BookOnLeft == true) {
            //Debug.Log("Shake your booky maker"); 
            leftBookshelf.GetComponent<Animator>().SetTrigger("BookTrigger"); 
            canRumble = false; 
            BookSoundSource.PlayOneShot(ShelfRumble);
        }

        if(secondCounter >= rumbleTime && FlyTime >= 7 && BookIsFlying == false && canRumble == true && BookOnRight == true) {
            //Debug.Log("Shake your booky maker"); 
            rightBookshelf.GetComponent<Animator>().SetTrigger("BookTrigger"); 
            canRumble = false; 
            BookSoundSource.PlayOneShot(ShelfRumble);
        }

        //the behaviour for when the player catches the book
        if(Input.GetKeyDown("space") && BookIsFlying == true) {
            bookHealth -= 1; //lowers the health
            //healthBox.text = "Book HP: " + bookHealth; //updates the UI
             
            secondCounter = 0f; //resets the secondCounter
            //FlyTime = 100; 

            BookSoundSource.PlayOneShot(BookDamage);

            //if statement to swap the onLeft and onRight variables to relfect which is true, so certain functions fire correctly 
            if(BookOnLeft == true) { 
                MoveBookRight();
                } 
                else {
                     MoveBookLeft();
                    }

            RandomiseFlyTime(); //get a new random fly time
            BookIsFlying = false; //ensures the player cannot catch the book multiple times at once 
        } 

        if(Input.GetKeyDown("space") && BookIsFlying == false) {
            loseTimer -= 2; 
            timeBox.text = "Time Remaining: " + loseTimer;
        }
        //fuck you Paul

        if(bookHealth == 2) {
            BookHealth1.SetActive(false); 
            BookHealth2.SetActive(true); 
        }

        if(bookHealth == 1) {
            BookHealth2.SetActive(false); 
        }

        if(bookHealth == 3) {
            BookHealth1.SetActive(true);
            BookHealth2.SetActive(true); 
        }
        

        if(BookIsFlying == true && BookOnLeft == true) {
            transform.position += new Vector3(0,0,30) * Time.deltaTime;
        }
        //moves the book right

        if(BookIsFlying == true && BookOnRight == true) {
            transform.position += new Vector3(0,0,-30) * Time.deltaTime;
        }
        //moves the book left

        if(loseTimer <= 0f) {
            GameManage.GameManager.LoseScreen(); 
        }

        if(bookHealth == 0)
        {
            GameManage.GameManager.WinScreen();
        }
        //reset the scene upon a loss
    }

    public void RandomiseFlyTime()
    {
        FlyTime = Random.Range(1,9); //randomises the amount of seconds before the book flies
        rumbleTime = Random.Range(2,6);
        canRumble = true; 
    }

    public void MoveBookRight()
    {
        //Debug.Log("Amogus");
        BookOnRight = true; 
        BookOnLeft = false;
        transform.position = new Vector3(-5.5f, 0.87f, 7.2f);
    }
    //function to be activated by a trigger

    public void MoveBookLeft()
    {
        //Debug.Log("Sussy");
        BookOnRight = false; 
        BookOnLeft = true; 
        transform.position = new Vector3(-5.5f, 0.87f, -7.2f); 
    }
    //function to be activated by a trigger


}
