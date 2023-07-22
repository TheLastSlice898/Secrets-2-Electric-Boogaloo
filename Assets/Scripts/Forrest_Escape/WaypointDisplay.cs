using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDisplay : MonoBehaviour
{
    public List<Color> Colour;
    public MeshFilter Death;
    public MeshFilter Win;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDrawGizmos()
    {

        foreach (Transform Waypoint in transform)
        {
            Gizmos.color = Colour[1];
            Gizmos.DrawWireSphere(Waypoint.position, 0.5f);

            if (Waypoint.gameObject.GetComponent<ForkScript>() != null)
            {
                Gizmos.DrawWireCube(Waypoint.position + Vector3.up, new Vector3(0.5f, 0.5f, 0.5f));
            }
            if (Waypoint.gameObject.GetComponent<Death>() != null)
            {
                Gizmos.DrawWireMesh(Death.sharedMesh, 0, Waypoint.position + Vector3.up, Quaternion.LookRotation(Vector3.up, Vector3.up), new Vector3(0.5f, 0.5f, 0.5f));
            }
            if (Waypoint.gameObject.GetComponent<WinPoint>() != null)
            {
                Gizmos.DrawWireMesh(Win.sharedMesh, 0, Waypoint.position + Vector3.up, Quaternion.LookRotation(Vector3.up, Vector3.up), new Vector3(0.5f, 0.5f, 0.5f));
            }
        }

        Gizmos.color = Colour[0];
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
}
