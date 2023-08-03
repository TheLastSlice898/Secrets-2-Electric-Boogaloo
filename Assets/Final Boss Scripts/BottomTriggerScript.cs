using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTriggerScript : MonoBehaviour
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
        Debug.Log("Sending Magic Up");
        other.gameObject.GetComponent<ProjectileBehaviour>().projPosition = 2;
    }
}
