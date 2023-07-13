using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PotionMakerScript : MonoBehaviour
{
    public GameObject[] correctIngredients;                                             // Array of correct ingredients
    public GameObject[] wrongIngredients;                                               // Array of wrong ingredients
    public Transform spawnLocation;                                                     // Reference to spawn location object
    public string winSceneName = "Win_Scene";                                           // Name of the win scene
    public string gameOverSceneName = "Game_Over";                                      // Name of the game over scene
    public int maxWrongClicks = 3;                                                      // Maximum allowed wrong clicks
    public Slider hpSlider;                                                             // Reference to the hp slider component
    public float spawnDelay = 1f;                                                       // Delay between each spawn
    public float clickTimeout = 3f;                                                     // Time allowed to click an object

    private int clickedCorrectIngredients = 0;                                          // Counter for clicked correct ingredients
    private int wrongClicks = 0;                                                        // Counter for wrong clicks
    private bool canAppearAgain = true;                                                 // Flag to control appearance of incorrect ingredients

    private void Start()
    {
        hpSlider.maxValue = maxWrongClicks;                                             // Set the maximum value of the slider to the maximum wrong clicks
        hpSlider.value = 0;                                                             // Initialize the slider value to 0
        StartCoroutine(SpawnObjects());                                                 // Start spawning the ingredients
    }

    private IEnumerator SpawnObjects()
    {
        List<GameObject> allIngredients = new List<GameObject>();

        //Combine correct and wrong ingredients into a single list

        allIngredients.AddRange(correctIngredients);
        allIngredients.AddRange(wrongIngredients);

        //Shuffle the list of ingredients

        ShuffleList(allIngredients);

        foreach (GameObject ingredient in allIngredients)
        {
            //Instantiate the ingredient at the spawn position

            GameObject spawnedIngredient = Instantiate(ingredient, GetRandomPositionInArea(), Quaternion.identity);

            if (ingredient.CompareTag("Correct_Ingredient"))
            {
                //Attach the ClickableObject script to the spawned correct ingredient

                ClickableObject clickableObject = spawnedIngredient.AddComponent<ClickableObject>();
                clickableObject.canAppearAgain = canAppearAgain;
            }
            else if (ingredient.CompareTag("Incorrect_Ingredient"))
            {
                StartCoroutine(TimeoutObject(spawnedIngredient));                           //Start the timeout coroutine for incorrect ingredients
            }

            //Wait for a delay before spawning the next ingredient

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator TimeoutObject(GameObject obj)
    {
        yield return new WaitForSeconds(clickTimeout);

        //Check if the object is still active (not clicked) after the timeout

        if (obj && obj.activeSelf)
        {
            wrongClicks++;
            hpSlider.value = wrongClicks;

            if (wrongClicks > maxWrongClicks)
            {
                SceneManager.LoadScene(gameOverSceneName);                                  //Load the game over scene if maximum wrong clicks reached

                Debug.Log("Nuh you can't game over");
            }
            if (obj)
            {
                Destroy(obj);
            }
        }
    }

    private Vector3 GetRandomPositionInArea()
    {
        Vector3 areaCenter = spawnLocation.position;                                         //Get the position of the spawn location object
        Vector3 areaSize = spawnLocation.localScale;                                         //Get the scale of the spawn location object

        Vector3 minPosition = areaCenter - areaSize / 2f;                                    //Calculate the minimum position within the spawn area
        Vector3 maxPosition = areaCenter + areaSize / 2f;                                    //Calculate the maximum position within the spawn area

        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),                                      //Get a random x position within the area bounds
            Random.Range(minPosition.y, maxPosition.y),                                      //Get a random y position within the area bounds
            Random.Range(minPosition.z, maxPosition.z));                                     //Get a random z position within the area bounds

        return randomPosition;                                                               //Return the random position within the area
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
                        SceneManager.LoadScene(winSceneName);                               //Load the win scene if all correct ingredients have been clicked
                    }

                    Destroy(hitObject);
                }
                else if (hitObject.CompareTag("Incorrect_Ingredient"))
                {
                    wrongClicks++;

                    if (wrongClicks > maxWrongClicks)
                    {
                        SceneManager.LoadScene(gameOverSceneName);                          //Load the game over scene if maximum wrong clicks reached
                    }
                   
                    //Deactivate the incorrect ingredient object instead of destroying it

                    hitObject.SetActive(false);
                }

                //Update the slider value based on the number of wrong clicks

                hpSlider.value = wrongClicks;
            }
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;                                                                  //Get the total number of elements in the list

        //Loop through the list in reverse order

        while (n > 1)
        {
            n--;                                                                            //Decrement the index to get the current position
            int k = Random.Range(0, n + 1);                                                 //Generate a random index between 0 and n (inclusive)

            //Swap the element at index k with the element at index n

            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public class ClickableObject : MonoBehaviour
    {
       public bool canAppearAgain;                                                     //Flag to control appearance of Incorrect Ingredients


        private void OnMouseDown()
        {
            if (gameObject.CompareTag("Correct_Ingredient"))
            {
                if (!canAppearAgain)
                {
                    //Object with the tag "Correct_Ingredient" was already clicked and should not appear again
                    gameObject.SetActive(false);
                }
                else
                {
                    canAppearAgain = false;
                }
            }
            else if (gameObject.CompareTag("Incorrect_Ingredient"))
            {
                // Object with the tag "Incorrect_Ingredient" was clicked, so it can continue to appear
            }
        }
    }
}
