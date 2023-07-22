using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToTheBoss : MonoBehaviour
{

    public GameObject[] pileofLogs;
    public GameObject[] magicBlockade;
    public Transform spawnLocation;
    public Slider hpSlider;
    public Text correctChoicesCounter; 
    public string winSceneName = "Win_Scene";
    public string gameOverSceneName = "Game_Over";
    public int maxWrongPress = 3;

    public int correctSelection = 0;
    public float spawnDelay = 2f;                                                                                                   //Delay between each spawn
    //public float pressTimeout = 3f;                                                                                                 //Time allowed to click an object
    public float deactivateDuration = 1f;
    public float wrongPress = 0;
    public Vector3 ingredientScale = new Vector3(2f, 2f, 2f);                                                                       //Adjust the scale values as per your requirement

    private GameObject currentlyActiveObject;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider.maxValue = maxWrongPress;
        hpSlider.value = 0;

        correctChoicesCounter.text = correctSelection.ToString();

    }

    private IEnumerator SpawnHazard()
    {
            List<GameObject> allHazards = new List<GameObject>();

            allHazards.AddRange(pileofLogs);
            allHazards.AddRange(magicBlockade);

            ShuffleList(allHazards);

            foreach (GameObject hazard in allHazards)
            {

                if (hazard != null) // Deactivate the previously active hazard
                {
                    if (currentlyActiveObject != null)
                    {
                        currentlyActiveObject.SetActive(false);
                    }

                    hazard.SetActive(true); // Activate the new hazard

                    currentlyActiveObject = hazard; // Update the currently active hazard reference

                    yield return new WaitForSeconds(spawnDelay);
                }

            }
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

    private IEnumerator TimeoutObject(GameObject obj)
    {
        //yield return new WaitForSeconds(pressTimeout);

            if (obj && obj.activeSelf)                                                                                                   //Check if the object is still active (not clicked) after the timeout
            {
                obj.SetActive(false);
                yield return new WaitForSeconds(spawnDelay);
                obj.SetActive(true);
            }
        
    }

    private IEnumerator DeactivateAndReactivate(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(deactivateDuration);
        obj.SetActive(true);

    }
    
    private Vector3 GetRandomPositionInArea()
    {
            Vector3 areaCenter = spawnLocation.position;                                                                                //Get the position of the spawn location object
            Vector3 areaSize = spawnLocation.localScale;                                                                                //Get the scale of the spawn location object

            Vector3 minPosition = areaCenter - areaSize / 2f;                                                                           //Calculate the minimum position within the spawn area
            Vector3 maxPosition = areaCenter + areaSize / 2f;                                                                           //Calculate the maximum position within the spawn area

            Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),                                                                                 //Get a random x position within the area bounds
            Random.Range(minPosition.y, maxPosition.y),                                                                                 //Get a random y position within the area bounds
            Random.Range(minPosition.z, maxPosition.z));                                                                                //Get a random z position within the area bounds

        return randomPosition;                                                                                                          //Return the random position within the area
    
    }

    private void IncrementCounter()
    {
        correctSelection++;
        correctChoicesCounter.text = correctSelection.ToString();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentlyActiveObject != null && currentlyActiveObject.CompareTag("PileOfLogs"))
            {
                correctSelection++;

                if (correctSelection == 5)
                {
                    SceneManager.LoadScene(winSceneName);
                }

                currentlyActiveObject.SetActive(false);
                StartCoroutine(SpawnHazard());
            }
            else
            {
                wrongPress++;

                if (wrongPress > maxWrongPress)
                {
                    SceneManager.LoadScene(gameOverSceneName);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentlyActiveObject != null && currentlyActiveObject.CompareTag("MagicBlockade"))
            {
                correctSelection++;

                if (correctSelection == 5)
                {
                    SceneManager.LoadScene(winSceneName);
                }

                currentlyActiveObject.SetActive(false);
                StartCoroutine(SpawnHazard());
            }
            else
            {
                wrongPress++;

                if (wrongPress > maxWrongPress)
                {
                    SceneManager.LoadScene(gameOverSceneName);
                }
            }
        }

        hpSlider.value = wrongPress;
    }
}

