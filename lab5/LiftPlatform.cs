using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPlatform : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 2f;
    private int waypointIndex = 0;
    private bool playerOnPlatform = false;

    void Update()
    {
        if (waypoints.Count < 2) return;

        if (playerOnPlatform)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex], speed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex])
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.transform.SetParent(null);
        }
    }
}