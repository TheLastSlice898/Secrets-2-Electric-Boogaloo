using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
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
           transform.position =  Vector3.MoveTowards(transform.position, CamTrans.position, Speed * Time.deltaTime);
        }
        
        gameObject.transform.LookAt(PlayerLook);
    }
}
