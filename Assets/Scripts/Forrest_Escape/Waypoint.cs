using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform[] Waypoints;

    public int CurrentPath;
    // Start is called before the first frame update
    void Start()


    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        

        if (currentWaypoint == null)
        {
            return Waypoints[CurrentPath].transform.GetChild(0);
        }
        if (currentWaypoint.GetSiblingIndex() < Waypoints[CurrentPath].transform.childCount - 1)
        {
            return Waypoints[CurrentPath].transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            Debug.Log("i win :)");
            return currentWaypoint.transform;
        }

    }

}