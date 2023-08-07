using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject button;
    public Transform[] spawnTransform;
    // Start is called before the first frame update
    void Start()
    {   int RandomInt = Random.Range(0, spawnTransform.Length);
        button.transform.position = spawnTransform[RandomInt].position;
        

    }

   
}


