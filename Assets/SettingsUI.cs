using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsUI : MonoBehaviour
{
    public TMP_Dropdown DropDown;
    public Toggle SoundToggle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    }



    public void CheckDropDown()
    {
        GameManage.GameManager.GetComponent<Settings>().FullScreenInt = DropDown.value;
    }
    public void CheckToggle()
    {
        GameManage.GameManager.GetComponent<Settings>().SoundToggle = SoundToggle.isOn;
    }
}
