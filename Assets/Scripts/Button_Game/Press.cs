using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press : MonoBehaviour
{
    public GameObject button;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }


    public void OnMouseDown()
    {
        //Debug.Log("Pressed left-click.");
        isPressed = true;
    }

    public void OnMouseUp() 
    {
        SceneManager.LoadScene("Button_Game");
    }

}
