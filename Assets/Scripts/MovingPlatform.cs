using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider Collider)
    {
        //when the player is in the collider, set the player to be the parent of the platform
        if (Collider.gameObject.name == "Player")
        {
            Collider.transform.SetParent(transform);
        }
    }

        private void OnTriggerExit(Collider Collider)
    {
        //when the player is not in the collider, set the player to be the not be the parent of the platform
        if (Collider.gameObject.name == "Player")
        {
            Collider.transform.SetParent(null);
        }
    }

}
