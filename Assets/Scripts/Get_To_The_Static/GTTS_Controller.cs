using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GTTS_Controller : MonoBehaviour
{
    public GameObject[] sceneObjects;
    public Slider hpSlider;
    public Transform spawnLocation;
    public int maxLossConditions = 3; // Change to 3
    public int maxWinConditions = 10; // Change to 10
    private int winConditionsMet = 0;
    private int lossConditionsMet = 0;
    private GameObject activeObject;
    public float prefabLifetime = 1f; // Lifetime of each prefab

    private void Start()
    {
        hpSlider.maxValue = maxLossConditions;
        hpSlider.value = 0;
        SpawnRandomPrefab();
    }

    public void WinConditionMet()
    {
        winConditionsMet++;
        if (winConditionsMet >= maxWinConditions)
        {
            GameManage.GameManager.WinScreen();                                                                       //Load the win scene if all correct ingredients have been clicked

        }
        else
        {
            SpawnRandomPrefab();
        }
    }

    public void LossConditionMet()
    {
        lossConditionsMet++;
        if (lossConditionsMet >= maxLossConditions)
        {
            GameManage.GameManager.LoseScreen();                                                                       //Load the win scene if all correct ingredients have been clicked
        }
        else
        {
            SpawnRandomPrefab();
        }
        hpSlider.value = lossConditionsMet;
    }



    private void SpawnRandomPrefab()
    {
        if (activeObject != null)
        {
            Destroy(activeObject);
        }

        int randomIndex = Random.Range(0, sceneObjects.Length);
        GameObject randomPrefab = sceneObjects[randomIndex];
        activeObject = Instantiate(randomPrefab, spawnLocation.position, spawnLocation.rotation);

        GTTS_Stairs stairsScript = activeObject.GetComponent<GTTS_Stairs>();
        if (stairsScript != null)
        {
            stairsScript.controller = this;
        }

        GTTS_Debris debrisScript = activeObject.GetComponent<GTTS_Debris>();
        if (debrisScript != null)
        {
            debrisScript.controller = this;
        }

        GTTS_Magic magicScript = activeObject.GetComponent<GTTS_Magic>();
        if (magicScript != null)
        {
            magicScript.controller = this;
        }

        StartCoroutine(TimeoutObject(activeObject));
    }
    private IEnumerator TimeoutObject(GameObject obj)
    {
        yield return new WaitForSeconds(prefabLifetime);
        LossConditionMet(); // Called when prefab lifetime expires
    }
}
