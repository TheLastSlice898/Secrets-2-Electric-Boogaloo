using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GTTS_Stairs : MonoBehaviour
{
    public AudioClip RightVoice;
    public AudioClip LeftVoice;
    public GameObject Stairs;


    private AudioClip selectedAudio;

    public bool winConditionMet;
    public bool lossConditionMet;
    public bool canAppearAgain;

    public float pressTimeout = 3f;                                                                                                 //Time allowed to click an object
    private float lastKeyPressTime = 0f;

    private GTTS_Controller controllerScript;
    //private GTTS_ObjectPool ObjectPoolManager;

    private void Awake()
    {
        controllerScript = FindObjectOfType<GTTS_Controller>(); // Get a reference to the GTTS_Controller script
        PlayRandomAudio();
    }

    private void PlayRandomAudio()
    {
        AudioClip selectedAudio = Random.Range(0f, 1f) < 0.5f ? RightVoice : LeftVoice;

        GetComponent<AudioSource>().clip = selectedAudio; //play the selected audio source
        GetComponent<AudioSource>().Play();



    }


    private void Update()
    {
        if (Time.time - lastKeyPressTime > pressTimeout)
        {
            lossConditionMet = true;
            controllerScript.LossConditionMet(); // Inform the controller script
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && selectedAudio == RightVoice)
        {
            winConditionMet = true;
            lastKeyPressTime = Time.time;
            Debug.Log("Right");
            controllerScript.WinConditionMet(); // Inform the controller script
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && selectedAudio == LeftVoice)
        {
            lossConditionMet = true;
            controllerScript.LossConditionMet();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedAudio == LeftVoice)
        {
            winConditionMet = true;
            lastKeyPressTime = Time.time;
            Debug.Log("Left");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedAudio == RightVoice)
        {
            lossConditionMet = true;
            controllerScript.LossConditionMet();
        }
    }
    private void WinOrLossConditionMet()
    {
        GTTS_Controller.Instance.WinConditionMet();  // When a win or loss condition is met, you can call ActivateRandomObject from the ObjectPoolManager
        GTTS_Controller.Instance.LossConditionMet();
    }
}





