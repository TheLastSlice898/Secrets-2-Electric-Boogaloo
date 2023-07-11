using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform Waypoints;
    public bool PlayerDies;
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
            return Waypoints.transform.GetChild(0);
        }
        if (currentWaypoint.GetSiblingIndex() < Waypoints.transform.childCount - 1)
        {
            return Waypoints.transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {

            if (currentWaypoint.transform.GetComponent<Death>() != null)
            {
                PlayerDies = currentWaypoint.transform.GetComponent<Death>().DeathReturn();
            }
            Debug.Log("i win :)");
            return currentWaypoint.transform;
        }

    }

}