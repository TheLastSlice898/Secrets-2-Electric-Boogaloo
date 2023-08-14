using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTTS_Debris : MonoBehaviour
{
    public AudioSource pixieGrowl;
    public bool winConditionMet;
    public bool lossConditionMet; 
    public GTTS_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<GTTS_Controller>();
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            winConditionMet = true;
            Debug.Log("UpArrow Pressed - winConditionMet: " + winConditionMet);

            if (controller != null)
            {
                controller.WinConditionMet();
            }

            Destroy(gameObject);
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            winConditionMet = false;
            Debug.Log("UpArrow Not Pressed - winConditionMet: " + winConditionMet);

            if (controller != null)
            {
                controller.LossConditionMet();
            }

            Destroy(gameObject);
        }
    }
}
