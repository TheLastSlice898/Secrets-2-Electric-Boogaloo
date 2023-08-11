using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GTTS_Stairs : MonoBehaviour
{
    public GameObject stairsLR;
    public GTTS_EventController controllerScript;
    public AudioSource rightVoice;
    public AudioSource leftVoice; 

    private bool playrightVoice = false;
    private bool playleftVoice = false; 

    void Start()
    {
        InitaliseAudioSource(); 
    }

    // Update is called once per frame
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) || playleftVoice = true)
        {
            controllerScript.WinConditionMet(1); 
        }
        else if()
        {
            controllerScript.LossConditionMet(1);
        }
    }

    private void InitaliseAudioSource()
    {
        rightVoice.clip = rightVoice; //assigning audio sources 
        leftVoice.clip = leftVoice;

        //Set one of the sources to initially play
        playrightVoice = Random.value <0.5f; //randomly true or false
        playleftVoice = !playAudioSource; 

        //Set inital audio source
        audioSource1.gameObject.SetActive(playrightVoice);
        audioSource.gameObject.SetActive(playleftVoice);
    }



    private void PlayRandomAudioSource()
    {
    if(playrightVoice.get)
        {
        rightVoice.Play();
    }
    else
    {
        leftVoice.Play();
    }
    }
}

