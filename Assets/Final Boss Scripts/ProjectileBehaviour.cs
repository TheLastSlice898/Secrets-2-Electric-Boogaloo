using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public int projPosition; 
    public float projSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        projSpeed = Random.Range(0.5f,.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(projPosition == 1) {
            transform.position += new Vector3(0,0,-5 * projSpeed) * Time.deltaTime; 
        }
    
        if(projPosition == 2) {
            transform.position += new Vector3(0,0,5 * projSpeed) * Time.deltaTime; 
        }

        if(projPosition == 3) {
            transform.position += new Vector3(15 * projSpeed,0,0) * Time.deltaTime; 
        }

        if(projPosition == 4) {
            transform.position += new Vector3(-15 * projSpeed,0,0) * Time.deltaTime; 
        }
    }
}
