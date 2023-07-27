using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawnScript : MonoBehaviour
{
    public GameObject currentIngredient;                                //Reference to currently spawned ingredient
    public Transform SpawnLocation;                                     //Spawn Area
    public GameObject[] correctIngredients;                             //Array of correct ingredients
    public GameObject[] wrongIngredients;                               //Array of wrong ingredients
    public Slider hpSlider;                                             //Reference to the hpSlider
    
    //True or false conditions 
    public bool isCorrectIngredient;
    public bool isWrongIngredient;
    public bool RightIngredientClick; 
    public bool WrongIngredientClick;

    public float spawnDelay = 10f;                                       //Delay between each spawn
    public float spawnRadius = 15f;                                      //Radius within which objects can spawn
    public float timerDuration = 10f;                                   //Duration of the timer
    private bool[] ingredientSpawnedFlags;                              //Tracks spawned ingreidients 

    
    private float timer;

    private void Start()
    {
        hpSlider = GameObject.FindObjectOfType<Slider>();               // Find the Slider component in the scene

        ingredientSpawnedFlags = new bool[correctIngredients.Length];   //Initialise flags array
        for (int i = 0; i < ingredientSpawnedFlags.Length; i++)
            {
            ingredientSpawnedFlags[i] = false;                          //Set all to false initally
            }
        timer = timerDuration;
        StartCoroutine(SpawnObjects());                                 //Starts coroutine
        StartCoroutine(CountdownTimer());                               //Starts coroutine
        
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
           
            Vector3 SpawnLocation = GetRandomPositionInArea();          //Generate a random position within the spawn location object
            SpawnLocation.y = 2f;                                       //Ensure objects spawn at ground level or desired height
                                  
            int ingredientIndex = FindUnspawnedIngredientIndex();       //Find an index of an unspawned ingredient
            if (ingredientIndex != -1)
            {
            //Instantiate the unspawned ingredient at the spawn position
                GameObject spawnedIngredient = Instantiate(correctIngredients[ingredientIndex], SpawnLocation, Quaternion.identity);
                ingredientSpawnedFlags[ingredientIndex] = true;         //Set the flag to true to indicate ingredient is spawned
                Debug.Log("ingredient flagged");
            }
            else
            {
                break;
            }
           
            //Instantiate a correct or wrong ingredient at the spawn position
            if (Random.value < 0.5f)
            {
                Instantiate(correctIngredients[Random.Range(0, correctIngredients.Length)], SpawnLocation, Quaternion.identity);
            }
            else
            {
                Instantiate(wrongIngredients[Random.Range(0, wrongIngredients.Length)], SpawnLocation, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private Vector3 GetRandomPositionInArea()                           //Generates the random position
    {

        Vector3 areaCenter = SpawnLocation.position;
        Vector3 areaSize = SpawnLocation.localScale;

        Vector3 minPosition = areaCenter - areaSize / 2f;
        Vector3 maxPosition = areaCenter + areaSize / 2f;

        Vector3 randomPosition = new Vector3(
             Random.Range(minPosition.x, maxPosition.x),
             Random.Range(minPosition.y, maxPosition.y),
             Random.Range(minPosition.z, maxPosition.z));

        return randomPosition;
    }

    private IEnumerator CountdownTimer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

       //Timer ran out, trigger event or action

        if (currentIngredient != null)
        {
            Destroy(currentIngredient);
            Debug.Log("Timer ran out");
        }

        StartCoroutine(SpawnObjects());                             //Allow next ingredient to spawn
    }


    private int FindUnspawnedIngredientIndex()
    {
        for (int i = 0; i < ingredientSpawnedFlags.Length; i++)
        {
            if (!ingredientSpawnedFlags[i])
            {
                return i;                                           //Return the index of the first unspawned ingredient
            }
        }

        return -1;                                                 //Return -1 if all ingredients have spawned
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))                            //Checking if object clicked is correct ingredient 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("Spawn_Location"))
                {
                    return;                                         //Ignore the SpawnLocation 
                }

                if (hitObject.CompareTag("Correct_Ingredient"))
                {
                    GameObject objectToDestroy = hitObject;
                    Destroy(objectToDestroy);
                }
                if (hitObject.CompareTag("Incorrect_Ingredient"))
                {
                    GameObject objectToDestroy = hitObject;
                    hpSlider.value -= 1f;
                    Destroy(objectToDestroy);
                }
            }

        }

    }
       }
  
