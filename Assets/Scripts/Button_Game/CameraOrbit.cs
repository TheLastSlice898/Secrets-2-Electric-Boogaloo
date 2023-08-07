using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float cameraSpeed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //transform rotate lets objects rotate objects around anty axis 
        //float x time.deltatime tells object to roate the current speed per second 
        transform.Rotate(0, cameraSpeed * Time.deltaTime, 0);
    }
}

// Thank you to LMHPOLY on youtube for the rotation tutorial
// https://youtu.be/iuygipAigew