using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Syste3m : MonoBehaviour
{
    public string LaSceneName;
    public AudioClip CurrentClip;
    public AudioSource MusicPlayer;
    // Update is called once per frame
    public void MusicPlay()
    {
        LaSceneName = GameManage.GameManager.SceneName;

        if (LaSceneName == "Menu")
        {
            CurrentClip = GameManage.GameManager.MusicClips[0];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Catch")
        {
            CurrentClip = GameManage.GameManager.MusicClips[1];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Repair")
        {
            CurrentClip = GameManage.GameManager.MusicClips[2];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Button")
        {
            CurrentClip = GameManage.GameManager.MusicClips[3];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Dungeon")
        {
            CurrentClip = GameManage.GameManager.MusicClips[4];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Pursuit")
        {
            CurrentClip = GameManage.GameManager.MusicClips[5];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Potion")
        {
            CurrentClip = GameManage.GameManager.MusicClips[6];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Get_To_The_Static")
        {
            CurrentClip = GameManage.GameManager.MusicClips[7];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "Boss")
        {
            CurrentClip = GameManage.GameManager.MusicClips[8];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }
        if (LaSceneName == "You_Won_Yippoee")
        {
            CurrentClip = GameManage.GameManager.MusicClips[9];
            MusicPlayer.clip = CurrentClip;
            MusicPlayer.Play();
        }





    }
}
