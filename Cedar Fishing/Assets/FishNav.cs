using UnityEngine;

public class FishNav : MonoBehaviour
{
    [Header("Patrol Settings")]
    [Tooltip("Array of waypoints the fish will swim between")]
    public Transform[] waypoints;

    [Tooltip("Speed at which the fish moves")]
    public float moveSpeed = 2f;

    [Tooltip("Speed at which the fish rotates to face direction")]
    public float rotationSpeed = 3f;

    [Tooltip("Distance from waypoint to consider it 'reached'")]
    public float waypointReachDistance = 0.5f;

    private int currentWaypointIndex = 0;

    void Start()
    {
        // Validation check
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to FishPatrol script!");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Get current target waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Calculate direction to target
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // Smoothly rotate to face the target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Move towards the target
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if we've reached the waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, targetWaypoint.position);
        if (distanceToWaypoint < waypointReachDistance)
        {
            // Move to next waypoint (loop back to start if at end)
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // Optional: Draw gizmos in editor to visualize the patrol path
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.cyan;

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null) continue;

            // Draw sphere at waypoint
            Gizmos.DrawWireSphere(waypoints[i].position, 0.3f);

            // Draw line to next waypoint
            int nextIndex = (i + 1) % waypoints.Length;
            if (waypoints[nextIndex] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[nextIndex].position);
            }
        }
    }
}