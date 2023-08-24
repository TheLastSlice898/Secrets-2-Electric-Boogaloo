using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public AudioSource BlockSource; 
    public AudioClip BlockNoise; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-1, 6, 2.5f); 
        transform.eulerAngles = new Vector3(90,270,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position = new Vector3(-1, 6, 2.5f); 
            transform.eulerAngles = new Vector3(90,270,0);
        }

        if(Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position = new Vector3(-1, 6, -2); 
            transform.eulerAngles = new Vector3(90,-270,0);
        }

        if(Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position = new Vector3(1.5f, 6, 0.4f); 
            transform.eulerAngles = new Vector3(90,0,0);
        }
        
        if(Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position = new Vector3(-3.5f, 6, 0.4f); 
            transform.eulerAngles = new Vector3(90,180,0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BossProjectile") 
        {
            //Debug.Log("No ouchies >:c"); 

            Destroy(other.gameObject);
            BlockSource.PlayOneShot(BlockNoise); 
        }
    }
}