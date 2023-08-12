/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnLocationScript;

public class GTTS_ObjectPool : MonoBehaviour
{
    public Transform spawnLocation;
    public GTTS_Controller[] sceneObjects; // Store references to GTTS_Controller prefab scripts
    public GTTS_Controller activeObject; // The currently active object
    public static GTTS_ObjectPool Instance { get; private set; }

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

    public void ReturnActiveObject()
    {
        // Return the active object to the pool (deactivate it)
        activeObject.SetActive(false);
    }

    public void ActivateRandomObject()
    {
        // Deactivate the current object if there is one
        if (activeObject != null)
        {
            activeObject.gameObject.SetActive(false);
        }

        // Instantiate and activate a new random object prefab
        int randomIndex = Random.Range(0, sceneObjects.Length);
        GTTS_Controller prefab = sceneObjects[randomIndex];
        GameObject instantiatedObject = Instantiate(prefab.gameObject, spawnLocation.position, spawnLocation.rotation);
        activeObject = instantiatedObject.GetComponent<GTTS_Controller>();
        activeObject.gameObject.SetActive(true);
    }
}

*/