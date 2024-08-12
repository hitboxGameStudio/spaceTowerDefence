using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public int[] waypointAngles;
    public float speed = 5f;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (currentWaypointIndex == waypoints.Length)
        {
            transform.position = new Vector3(1000, 1000, 1000);
            return;
        }
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float distance = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, distance);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                waypointAngles[currentWaypointIndex],
                transform.eulerAngles.z
            );
            currentWaypointIndex++;
        }
    }
}
