using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PotionMakerScript : MonoBehaviour
{
    public GameObject[] correctIngredients;                                                                                         //Array of correct ingredients
    public GameObject[] wrongIngredients;                                                                                           //Array of wrong ingredients
    public Transform spawnLocation;                                                                                                 //Reference to spawn location object
    public string winSceneName = "Win_Scene";                                                                                       //Name of the win scene
    public string gameOverSceneName = "Game_Over";                                                                                  //Name of the game over scene
    public int maxWrongClicks = 3;                                                                                                  //Maximum allowed wrong clicks
    public Slider hpSlider;                                                                                                         //Reference to the hp slider component
    public float spawnDelay = 1f;                                                                                                   //Delay between each spawn
    public float clickTimeout = 3f;                                                                                                 //Time allowed to click an object
    public float deactivateDuration = 1f;                                                                                           //Delay after deactivation
    public Vector3 ingredientScale = new Vector3(2f, 2f, 2f);                                                                       //Adjust the scale values as per your requirement
    

    private int clickedCorrectIngredients = 0;                                                                                      //Counter for clicked correct ingredients
    private int wrongClicks = 0;                                                                                                    //Counter for wrong clicks
    private bool canAppearAgain = true;                                                                                             //Flag to control reappearance of ingredients

    private void Start()
    {
        hpSlider.maxValue = maxWrongClicks;                                                                                         //Set the maximum value of the slider to the maximum wrong clicks
        hpSlider.value = 0;                                                                                                         //Initialize the slider value to 0
        StartCoroutine(SpawnObjects());                                                                                             //Start spawning the ingredients
    }

    private IEnumerator SpawnObjects()
    {
        
            List<GameObject> allIngredients = new List<GameObject>();                                                               //Create a list to store all the ingredients

            allIngredients.AddRange(correctIngredients);                                                                            //Add the correct ingredients to the list
            allIngredients.AddRange(wrongIngredients);                                                                              //Add the wrong ingredients to the list

            ShuffleList(allIngredients);                                                                                                //Shuffle the list of ingredients

            foreach (GameObject ingredient in allIngredients)
            {
                GameObject spawnedIngredient = Instantiate(ingredient, GetRandomPositionInArea(), Quaternion.identity);                 //Instantiate the ingredient at the spawn position

                spawnedIngredient.transform.localScale = ingredientScale;                                                               //Set the scale of the object

                
                StartCoroutine(OnMouseDown());                                                                                      //Start OnMouseDown coroutine

                StartCoroutine(TimeoutObject(spawnedIngredient));                                                                   //Start the timeout coroutine for incorrect ingredients, passing the spawned ingredient as an argument
                                                                                                                                   

                yield return new WaitForSeconds(spawnDelay);                                                                            //Wait for a delay before spawning the next ingredient
            }
            yield return new WaitForSeconds(clickTimeout);                                                                          //Wait for the specified timeout duration
               
    }


    private IEnumerator TimeoutObject(GameObject obj)
    {
        while (canAppearAgain)
        {
            yield return new WaitForSeconds(clickTimeout);

            if (obj && obj.activeSelf)                                                                                                   //Check if the object is still active (not clicked) after the timeout
            {

                obj.SetActive(false);
                yield return new WaitForSeconds(spawnDelay);
                obj.SetActive(true);
            }
        }
    }


    private Vector3 GetRandomPositionInArea()
    {
        Vector3 areaCenter = spawnLocation.position;                                                                                //Get the position of the spawn location object
        Vector3 areaSize = spawnLocation.localScale;                                                                                //Get the scale of the spawn location object

        Vector3 minPosition = areaCenter - areaSize / 2f;                                                                           //Calculate the minimum position within the spawn area
        Vector3 maxPosition = areaCenter + areaSize / 2f;                                                                           //Calculate the maximum position within the spawn area

        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),                                                                             //Get a random x position within the area bounds
            Random.Range(minPosition.y, maxPosition.y),                                                                             //Get a random y position within the area bounds
            Random.Range(minPosition.z, maxPosition.z));                                                                            //Get a random z position within the area bounds

        return randomPosition;                                                                                                      //Return the random position within the area
    }


    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("Correct_Ingredient"))
                {
                    clickedCorrectIngredients++;

                    if (clickedCorrectIngredients == correctIngredients.Length)
                    {
                        GameManage.GameManager.NextScene();                                                                    //Load the win scene if all correct ingredients have been clicked
                    }

                    Destroy(hitObject);
                }
                else if (hitObject.CompareTag("Incorrect_Ingredient"))
                {
                    wrongClicks++;
                    

                    if (wrongClicks > maxWrongClicks)
                    {
                        GameManage.GameManager.ResetScene(); ;                                                                  //Load the game over scene if maximum wrong clicks reached
                    }

                    StartCoroutine(DeactivateAndReactivate(hitObject));                                                             //Start the Coroutine to deactivate and reactivate the object

                }
                                
                hpSlider.value = wrongClicks;                                                                                       //Update the slider value based on the number of wrong clicks
                
            }
        }
    }

    private IEnumerator DeactivateAndReactivate(GameObject obj)
    {
        obj.SetActive(false);

        yield return new WaitForSeconds(deactivateDuration);

        obj.SetActive(true);

    }
    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;                                                                                                         //Get the total number of elements in the list

        while (n > 1)                                                                                                               //Loop through the list in reverse order
        {
            n--;                                                                                                                    //Decrement the index to get the current position
            int k = Random.Range(0, n + 1);                                                                                         //Generate a random index between 0 and n (inclusive)

            //Swap the element at index k with the element at index n

            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public IEnumerator OnMouseDown()
    {
            if (gameObject.CompareTag("Correct_Ingredient"))
            {
                if (!canAppearAgain)
                {
                    gameObject.SetActive(false);                                                                                        //Deactivate the game object if it has the tag "Correct_Ingredient" and should not appear again
                }
                else
                {
                    canAppearAgain = true;                                                                                              //Set the canAppearAgain flag to true if the game object can appear again
                }
            }

            
           
        yield return new WaitForSeconds(clickTimeout);                                                                              // Wait for the specified timeout duration

    }
}