using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLeftStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Left Trigger entered");
        other.gameObject.GetComponent<CatchTheBook>().MoveBookLeft();
        other.gameObject.GetComponent<CatchTheBook>().RandomiseFlyTime();
        other.gameObject.GetComponent<CatchTheBook>().BookIsFlying = false;
        other.gameObject.GetComponent<CatchTheBook>().secondCounter = 0;
    }
}
