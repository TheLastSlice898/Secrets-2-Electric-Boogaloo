using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToTheBoss : MonoBehaviour
{
    public GameObject pileOfLogs;
    public GameObject magicBarricade;
    public Transform spawnLocation;                                                                             //Specific location for objects to spawn
    public int correctPressesNeeded = 5;                                                                        //Number of correct presses needed to win
    public int incorrectPressesAllowed = 3;                                                                     //Number of incorrect presses allowed before losing
    public string winSceneName = "Win_Scene";                                                                   //Name of the win scene
    public string gameOverSceneName = "Game_Over";                                                              //Name of the game over scene
    public Text correctPressesText;                                                                             //Reference to the UI Text element to display correct presses


    private GameObject currentObject;
    private int correctPresses = 0;
    private int incorrectPresses = 0;
    private bool canPress = true;                                                                               //To prevent button presses during the delay

    private void Start()
    {
        StartCoroutine(ShowObjectsWithDelay());
    }

    private IEnumerator ShowObjectsWithDelay()
    {
        while (correctPresses < correctPressesNeeded && incorrectPresses < incorrectPressesAllowed)
        {
            yield return new WaitForSeconds(2f);

            if (correctPresses < correctPressesNeeded && incorrectPresses < incorrectPressesAllowed)
            {
                ShowRandomObject();
            }
        }

        if (correctPresses >= correctPressesNeeded)
        {
            //Game over, player won!
            Debug.Log("You win!");
            SceneManager.LoadScene(winSceneName);                                                               //Load the win scene if all correct ingredients have been clicked
        }
        else
        {
            //Game over, player lost!
            Debug.Log("Game over. You lose!");
            SceneManager.LoadScene(gameOverSceneName);                                                          //Load the game over scene if maximum wrong clicks reached
        }
    }

    private void ShowRandomObject()
    {
        if (Random.Range(0, 2) == 0)
        {
            currentObject = pileOfLogs;
        }
        else
        {
            currentObject = magicBarricade;
        }

        currentObject.transform.position = spawnLocation.position;                                              //Set the position of the current object to the spawn location
        currentObject.SetActive(true);
    }

    private void Update()
    {
        if (canPress)
        {
            if (Input.GetKeyDown(KeyCode.A) && currentObject == pileOfLogs)
            {
                CorrectPress();
            }
            else if (Input.GetKeyDown(KeyCode.D) && currentObject == magicBarricade)
            {
                CorrectPress();
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                IncorrectPress();
            }
        }
    }

    private void CorrectPress()
    {
        canPress = false;                                                                                       //Disable button presses during delay
        currentObject.SetActive(false);

        correctPresses++;

        StartCoroutine(EnableButtonPress());
    }

    private void IncorrectPress()
    {
        canPress = false;                                                                                       //Disable button presses during delay
        currentObject.SetActive(false);

        incorrectPresses++;

        StartCoroutine(EnableButtonPress());
    }

    private IEnumerator EnableButtonPress()
    {
        yield return new WaitForSeconds(2f);
        canPress = true;                                                                                         //Enable button presses after the delay
        ShowObjectsWithDelay();
    }
}

