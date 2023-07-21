using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleRunMovement : MonoBehaviour
{
    [SerializeField] private Waypoint WaypointScript;

    public float MoveSpeed;

    public int CurrentPoint;

    private Transform currentWaypoint;

    public bool MoveLeft;
    public bool MoveRight;
    public bool HitWall;
    public float DistanceThreshhold;
    public float PlayerInput;

    public float timehold;
    public float TimeMulti = 1f;
    [SerializeField] private bool Death;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = WaypointScript.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        
        currentWaypoint = WaypointScript.GetNextWaypoint(currentWaypoint);
    }


    public void TurnLeft()
    {
        MoveLeft = true;
        //print("im going left");
    }
    public void TurnRight()
    {
        MoveRight = true;
        //print("im going right");
    }

    // Update is called once per frame
    void Update()
    {
        
        float PlayerInp = Input.GetAxis("Horizontal");

        PlayerInput = PlayerInp;
        if (PlayerInp > 0.1f)
        {
            TurnRight();
        }
        else
        {
            MoveRight = false;
        }
        if (PlayerInp < -0.1f)
        {
            TurnLeft();
        }
        else
        {
            MoveLeft = false;
        }


        
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, ((MoveSpeed * TimeMulti) * Time.deltaTime));


        if (Vector3.Distance(transform.position, currentWaypoint.position) < DistanceThreshhold)
        {
            
            if(WaypointScript.PlayerDies == true)
            {
                DeathScript();
            }
            //Debug.Log(currentWaypoint.GetSiblingIndex());
            if (MoveRight)
            {
                if (currentWaypoint.GetComponent<ForkScript>() == null)
                {
                    goto noscript;
                }

                if (currentWaypoint.GetComponent<ForkScript>().RightPath == true)
                {
                    Transform NewTransfrom = currentWaypoint.GetComponent<ForkScript>().TransReturn();
                    WaypointScript.GetComponent<Waypoint>().Waypoints = NewTransfrom;
                    ResetIndex();

                    currentWaypoint = WaypointScript.GetNextWaypoint(currentWaypoint);
                    transform.LookAt(currentWaypoint);
                    goto next;
                }
                else
                {

                    print("cant turn right");
                    goto wrongdirection;
                }



            }
            if (MoveLeft)
            {
                if (currentWaypoint.GetComponent<ForkScript>() == null)
                {
                    goto noscript;
                }

                if (currentWaypoint.GetComponent<ForkScript>().LeftPath == true)
                {
                    Transform NewTransfrom = currentWaypoint.GetComponent<ForkScript>().TransReturn();
                    WaypointScript.GetComponent<Waypoint>().Waypoints = NewTransfrom;
                    ResetIndex();

                    currentWaypoint = WaypointScript.GetNextWaypoint(currentWaypoint);
                    transform.LookAt(currentWaypoint);
                    goto next;
                }
                else
                {
                    print("cant turn left");
                    goto wrongdirection;
                }
            }
            
            wrongdirection:
            noscript:
            {
                currentWaypoint = WaypointScript.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
            
        }
        next:
        //ways for me to debug the original scripts

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerFirstIndex();
        //}
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ResetIndex();
        }
        if (HitWall == true)
        {
            Debug.Log("ow that hurts");
        }
    }
    public void ResetIndex()
    {
        currentWaypoint = WaypointScript.Waypoints.transform.GetChild(0);
    }

    public void DeathScript()
    {
        GameManage.GameManager.ResetScene();
    }
    public void PlayerFirstIndex()
    {


        int Child = currentWaypoint.GetSiblingIndex();
        Debug.Log($"im at the {Child} point");
    }
    void OnCollisionEnter(Collision Collider)
    {
    HitWall = true;
    }
    void OnCollisionExit(Collision Collider){
    HitWall = false;
    }
}
