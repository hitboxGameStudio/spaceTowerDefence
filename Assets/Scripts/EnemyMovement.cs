using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints; // Waypoint'leri tutacak dizi
    public float speed = 5f; // Objenin hareket h�z�
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return; // Waypoint yoksa ��k

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        float distance = speed * Time.deltaTime;
        Debug.Log(waypoints[currentWaypointIndex].position);
        Debug.Log(currentWaypointIndex);

        // Obje hedef waypoint'e yakla��r
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, distance);

        // Waypoint'e ula��ld�ysa bir sonraki waypoint'e ge�
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z,0);
        }
    }
}
