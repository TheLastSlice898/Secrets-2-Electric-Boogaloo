using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPage : MonoBehaviour
{
    public GameObject page; 
    public Transform[] movement; 

    void Start()
    {
        int RandomInt = Random.Range(0, movement.Length);
        page.transform.position = movement[RandomInt].position; 


    }

   

}
        