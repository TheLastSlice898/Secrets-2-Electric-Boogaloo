using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GTTS_Controller : MonoBehaviour
{
    public GameObject[] sceneObjects;
    public Slider hpSlider;
    public Transform spawnLocation;
    public int maxlossConditionMet = 2;
    private int winConditionMet = 0;
    private int lossConditionMet = 0;
    public GTTS_Stairs stairsScript;
    //public GTTS_ObjectPool objectPoolManager;
    //public GTTS_Debris debrisScript;
    //public GTTS_Magic magicScript; 
    private GameObject activeObject; // Reference to the active object

    private GTTS_Stairs instantiatedStairsScript;
    public static GTTS_Controller Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        hpSlider.maxValue = maxlossConditionMet;
        hpSlider.value = 0;
        int randomIndex = Random.Range(0, sceneObjects.Length);
        CreateNewObject();
        GameObject randomPrefab = sceneObjects[randomIndex];
        GameObject instantiatedObject = Instantiate(randomPrefab, spawnLocation.position, spawnLocation.rotation);
        instantiatedStairsScript = instantiatedObject.GetComponent<GTTS_Stairs>(); //Get the GTTS_Stairs script of the instantiated prefab
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void WinConditionMet()
    {
        winConditionMet++;
        Destroy(activeObject); // Destroy the active GameObject
        CreateNewObject(); // Create a new object

        if (winConditionMet == 10)
        {
            GameManage.GameManager.WinScreen();
        }
    }

    public void LossConditionMet()
    {
        lossConditionMet++;
        Destroy(activeObject); // Destroy the active GameObject
        CreateNewObject(); // Create a new object

        if (lossConditionMet == maxlossConditionMet)
        {
            GameManage.GameManager.LoseScreen();
        }
    }

    private void CreateNewObject()
    {
        int randomIndex = Random.Range(0, sceneObjects.Length);
        GameObject randomPrefab = sceneObjects[randomIndex];
        activeObject = Instantiate(randomPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}





