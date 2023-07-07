using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CardRight;
    public GameObject CardLeft;

    void OnDestroy()
    {

    }
    void ToggleLeft()
    {
        CardLeft.SetActive(true);
        
    }

    void ToggleRight()
    {
        CardRight.SetActive(true);
 
    }

    public void OnTriggerEnter(Collider other)
    {

        //Debug.Log("aaaaaaaaaa");
        if (other.gameObject.tag == "Left")
        {
            Debug.Log("Im the left");
            Destroy(other.gameObject);
            ToggleLeft();
        }
        if (other.gameObject.tag == "Right")
        {
            Debug.Log("Im the right");
            Destroy(other.gameObject);
            ToggleRight();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
  


        //check what side
        //toggle on card on side
    }

