using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPage : MonoBehaviour
{
    public GameObject page; 
    public Transform[] movement;
        
    private void Start()
    {
        StartCoroutine(PageMove());


    }

    private void Update()
    {
     

    }


    IEnumerator PageMove()
    {

        int RandomInt = Random.Range(0, movement.Length);

        //1
        yield return new WaitForSeconds(1);
        page.transform.position = movement[RandomInt].position;
        

    }
}
        