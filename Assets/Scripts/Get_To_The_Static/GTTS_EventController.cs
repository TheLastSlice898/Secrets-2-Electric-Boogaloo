using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GTTS_EventController : MonoBehaviour
{
    public GameObject[] QTEObjects;                                                                                                 //Array of Scene Items
    [SerializeField] private GameObject SpawnedQTE;
    //public GTTS_Stairs stairsScript;                                                                                                //Reference to stair Item Script
    //public GTTS_MagicBarracade stairsScript;                                                                                                //Reference to barracade Item Script
    //public GTTS_DebrisPile stairsScript;                                                                                                //Reference to Debris Item Script
    public Slider hpSlider;                                                                                                         //Reference to Slider 
    public int maxlossCondition = 2;                                                                                                //Loss condition for all scripts 0 = 1 thus 3 clicks = 2
    public Transform spawnLocation;                                                                                                 //Reference for spawn location
    public float spawnDelay = 1f;                                                                                                   //Delay between each spawn
    public float clickTimeout = 3f;                                                                                                 //Time allowed to click an object

    private int winConditionMet = 0;                                                                                                //Set winConditionMet to 0 at inital launch
    private int lossConditionMet = 0;                                                                                               //Set lossConditionMet to 0 at inital launch*/
    private bool canAppearAgain = true;                                                                                             //Flag to control reappearance of Scenes


    // Start is called before the first frame update
    void Start()
    {
        hpSlider.maxValue = maxlossCondition;                                                                                       //Set the maximum value of the slider to the maximum wrong clicks
        hpSlider.value = 0;                                                                                                         //Initialize the slider value to 0
                                                                                                                        //Spawned QTE is being duped from a prefab in the project folder.


        //sets
        //Start spawning the Scenes
    }



    public void SpawnQTE()
    {

        int randomLocation = Random.Range(0, 1);                                                                                    //Sets random range
        SpawnedQTE = Instantiate(QTEObjects[randomLocation], spawnLocation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void WinConditionMet(int amount)
    {
        winConditionMet += amount;
        Debug.Log("WinCondtionMet");
       
    }

    public void LossConditionMet(int amount)
    {
        lossConditionMet += amount;
        Debug.Log("LossConditionMet");
    }
}
