using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Waypoint'leri tutacak dizi
    public float speed = 5f; // Objenin hareket hýzý
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return; // Waypoint yoksa çýk

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float distance = speed * Time.deltaTime;
        Debug.Log(waypoints[currentWaypointIndex].position);
        Debug.Log(currentWaypointIndex);

        // Obje hedef waypoint'e yaklaþýr
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, distance);

        // Waypoint'e ulaþýldýysa bir sonraki waypoint'e geç
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z,0);
        }
    }
}
