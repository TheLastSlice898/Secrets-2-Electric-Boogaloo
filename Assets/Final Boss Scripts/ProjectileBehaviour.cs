using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int projPosition; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(projPosition == 1) {
            transform.position += new Vector3(0,0,-7) * Time.deltaTime; 
        }
    
        if(projPosition == 2) {
            transform.position += new Vector3(0,0,7) * Time.deltaTime; 
        }

        if(projPosition == 3) {
            transform.position += new Vector3(15,0,0) * Time.deltaTime; 
        }

        if(projPosition == 4) {
            transform.position += new Vector3(-15,0,0) * Time.deltaTime; 
        }
    }
}
