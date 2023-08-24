using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    public bool SoundToggle;
    public int FullScreenInt;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        
        if (SoundToggle)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0f;
        }


        if (FullScreenInt == 0)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
        if (FullScreenInt == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        if (FullScreenInt == 2)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void CheckDropDown()
    {
            
    }
}
