using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public bool SoundToggle;
    public int FullScreenInt;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        AudioListener MasterAudio = Camera.main.gameObject.GetComponent<AudioListener>();
        if (SoundToggle)
        {
            MasterAudio.enabled = SoundToggle;
        }
        else
        {
            MasterAudio.enabled = SoundToggle;
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
