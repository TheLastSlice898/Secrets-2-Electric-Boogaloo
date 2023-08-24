using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GTTS_Stairs : MonoBehaviour
{
    public AudioSource voiceSource;
    public AudioClip leftVoice;
    public AudioClip rightVoice;
    
    public bool winConditionMet;
    public bool lossConditionMet;

    public int Side;

    public GTTS_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<GTTS_Controller>();
        voiceSource = gameObject.GetComponent<AudioSource>();
        GenerateSide();
        PlayRandomClip();
        Debug.Log("playing Audio");


    }


public void GenerateSide()
{
Side = Random.Range(1,2);
}


  public void PlayRandomClip()

    {

        if (Side == 1)

        {

            voiceSource.clip = leftVoice;
            voiceSource.Play(); 

            Debug.Log("leftClip");
        }

        if (Side == 2) 

        {

            voiceSource.clip = rightVoice;
            voiceSource.Play();

            Debug.Log("rightClip");
        }
    }
   
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Side == 1)
        {
            controller.WinConditionMet();
            Debug.Log("LeftArrow Pressed - winConditionMet: " + winConditionMet);
            Destroy(gameObject);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && Side == 1)
         {
         winConditionMet = false;
         controller.LossConditionMet();
         Debug.Log("LeftArrow Not Pressed - winConditionMet: " + winConditionMet);
         }




       if (Input.GetKeyDown(KeyCode.RightArrow) && Side == 2)
            {
            controller.WinConditionMet();
            Debug.Log("LeftArrow Pressed - winConditionMet: " + winConditionMet);
                Destroy(gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Side == 2)
            {
                winConditionMet = false;
            controller.LossConditionMet();
                Debug.Log("LeftArrow Not Pressed - winConditionMet: " + winConditionMet);
            }
        }
    }

