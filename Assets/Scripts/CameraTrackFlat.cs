using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackFlat : MonoBehaviour
{
    public Transform CamTrans;
    public Transform PlayerLook;
    public float distancethreshold;

    public float Speed;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(CamTrans.position, gameObject.transform.position) > distancethreshold)
        {
            //this below is sex!!! I MADE THIS SLICE MDADE THIS WHILE MAKING A SMOOOTHIE
            //what do you have their....A SMOOTHIIE!
           transform.position = Vector3.MoveTowards(transform.position, CamTrans.position, Speed * (Time.deltaTime * (Vector3.Distance(CamTrans.position, gameObject.transform.position))));
           transform.position = new Vector3(transform.position.x, transform.position.y,-27f);
        }
        
        gameObject.transform.LookAt(PlayerLook);
    }
}
