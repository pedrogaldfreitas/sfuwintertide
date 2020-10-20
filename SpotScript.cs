using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotScript : MonoBehaviour
{
    [SerializeField]
    public GameObject NextSpot1;
    [SerializeField]
    public GameObject NextSpot2;
    [SerializeField]
    public GameObject NextSpot3;
    [SerializeField]
    public GameObject NextSpot4;


    public bool branchingPaths;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (NextSpot1 != null)
        {
            Gizmos.DrawLine(transform.position, NextSpot1.transform.position);
        }
        if (NextSpot2 != null)
        {
            Gizmos.DrawLine(transform.position, NextSpot2.transform.position);
        }
        if (NextSpot3 != null)
        {
            Gizmos.DrawLine(transform.position, NextSpot3.transform.position);
        }
        if (NextSpot4 != null)
        {
            Gizmos.DrawLine(transform.position, NextSpot4.transform.position);
        }

    }
}
