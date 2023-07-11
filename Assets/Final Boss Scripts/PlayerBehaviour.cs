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

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 3; 
        healthUI.text = "HP: " + PlayerHealth;

        TimeRemaining = 120; 

        Instantiate(BossPrefab,new Vector3(-1,6,-6),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = "HP: " + PlayerHealth;

        TimeRemaining -= Time.deltaTime;
        timeBox.text = "Time Remaining: " + (int)TimeRemaining;
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
}
