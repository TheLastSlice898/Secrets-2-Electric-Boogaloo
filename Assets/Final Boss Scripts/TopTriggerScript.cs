using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTriggerScript : MonoBehaviour
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
        Debug.Log("Sending Magic Down");
        other.gameObject.GetComponent<ProjectileBehaviour>().projPosition = 1;
    }
}
