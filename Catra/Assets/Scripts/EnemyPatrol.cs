using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float speed = 3f;
    public Transform[] waypoints; // Array to hold our patrol points

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Safety check: if no waypoints are assigned, do nothing
        if (waypoints.Length == 0) return;

        // 1. Move the enemy towards the current waypoint
        transform.position = Vector2.MoveTowards(
            transform.position, 
            waypoints[currentWaypointIndex].position, 
            speed * Time.deltaTime
        );

        // 2. Check if the enemy has reached the waypoint
        // We use 0.1f instead of 0 because floating point math is rarely exact
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint in the list
            currentWaypointIndex++;

            // 3. If we've reached the end of the list, loop back to the first one
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}