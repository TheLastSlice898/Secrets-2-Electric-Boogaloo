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
    public GTTS_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<GTTS_Controller>();
        voiceSource = gameObject.GetComponent<AudioSource>();
        PlayRandomClip();
        Debug.Log("playing Audio");


    }

  public void PlayRandomClip()

    {

        if (Random.Range(0, 2) == 0)

        {

            voiceSource.clip = leftVoice;
            voiceSource.Play(); 

            Debug.Log("leftClip");
        }

        else 

        {

            voiceSource.clip = rightVoice;
            voiceSource.Play();

            Debug.Log("rightClip");
        }
    }
   
    private void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.LeftArrow) && voiceSource.clip == leftVoice)
            {
                winConditionMet = true;
                Debug.Log("LeftArrow Pressed - winConditionMet: " + winConditionMet);

                if (controller != null)
                {
                    controller.WinConditionMet();
                }

                Destroy(gameObject);
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.LeftArrow) && voiceSource.clip == leftVoice)
            {
                winConditionMet = false;
                Debug.Log("LeftArrow Not Pressed - winConditionMet: " + winConditionMet);

                if (controller != null)
                {
                    controller.LossConditionMet();
                }

                Destroy(gameObject);
            }




        if (Input.GetKeyDown(KeyCode.RightArrow) && voiceSource.clip == rightVoice)
        {
            winConditionMet = true;
            Debug.Log("RightArrow Pressed - winConditionMet: " + winConditionMet);

            Destroy(gameObject);
         
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.LeftArrow) && voiceSource.clip == rightVoice)
        {
            winConditionMet = false;
            Debug.Log("RightArrow Not Pressed - winConditionMet: " + winConditionMet);

            Destroy(gameObject);
            if (!winConditionMet)
            {
                lossConditionMet = true;
            }
        }
    }
}