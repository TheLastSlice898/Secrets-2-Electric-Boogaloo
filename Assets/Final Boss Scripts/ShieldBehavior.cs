using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-1, 6, 2); 
        transform.eulerAngles = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")) {
            transform.position = new Vector3(-1, 6, 2); 
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if(Input.GetKeyDown("s")) {
            transform.position = new Vector3(-1, 6, -1.5f); 
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if(Input.GetKeyDown("d")) {
            transform.position = new Vector3(1, 6, 0.4f); 
            transform.eulerAngles = new Vector3(0,90,0);
        }
        
        if(Input.GetKeyDown("a")) {
            transform.position = new Vector3(-3, 6, 0.4f); 
            transform.eulerAngles = new Vector3(0,90,0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BossProjectile") 
        {
            Debug.Log("No ouchies >:c"); 

            Destroy(other.gameObject);
        }
    }
}