using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject BossPrefab; 

    public TextMeshProUGUI healthUI;
    public int PlayerHealth; 

    public TextMeshProUGUI timeBox; 
    public float TimeRemaining; 

    public int SpawnPosition; 
    public bool CanSpawn; 

    private List<int> SpawnTimeList = new List<int>() { 117, 114, 113, 110, 108, 107, 104, 102, 100, 100, 98, 95, 93, 92, 91, 91, 90 };
    public int currentSpawnTimeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 3; 
        healthUI.text = "HP: " + PlayerHealth;

        TimeRemaining = 120; 

        SpawnPosition = 0; 
        currentSpawnTimeIndex = 0; 
        CanSpawn = true; 
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = "HP: " + PlayerHealth;

        TimeRemaining -= Time.deltaTime;
        timeBox.text = "Time Remaining: " + (int)TimeRemaining;

        if((int)TimeRemaining == SpawnTimeList[currentSpawnTimeIndex] && CanSpawn == true) {
            SpawnProjectile(); 
            CanSpawn = false; 
            currentSpawnTimeIndex++; 
        }

        if (currentSpawnTimeIndex >= SpawnTimeList.Count)
            {
                currentSpawnTimeIndex = 0;
            }

        if ((int)TimeRemaining == SpawnTimeList[currentSpawnTimeIndex] && CanSpawn == false)
        {
            CanSpawn = true;
        }

        if(PlayerHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BossProjectile") 
        {
            PlayerHealth -= 1; 
            Debug.Log("Ouchies"); 

            Destroy(other.gameObject);
        }
    }

    void SpawnProjectile()
    {
        SpawnPosition = Random.Range(1,5); 

        if(SpawnPosition == 1) {
            Instantiate(BossPrefab,new Vector3(-1,6,13),Quaternion.identity); //top
        }

        if(SpawnPosition == 2) {
            Instantiate(BossPrefab,new Vector3(-1,6,-12),Quaternion.identity); //bottom
        }

        if(SpawnPosition == 3) {
            Instantiate(BossPrefab,new Vector3(-24,6,0.4f),Quaternion.identity); //left
        }

        if(SpawnPosition == 4) {
            Instantiate(BossPrefab,new Vector3(22,6,0.4f),Quaternion.identity); //right
        }
    }
}
