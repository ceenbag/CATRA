using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float speed = 1f;
    public Transform[] patrolPoints; // Array to hold Point A and Point B
    
    private int currentPointIndex = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Grab the SpriteRenderer to flip the sprite later
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (patrolPoints.Length == 0) return;

        // Move the enemy towards the current target patrol point
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        // Check distance to point, if less than 0.25 switch to next point
        if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.25f)
        {
            currentPointIndex++;
            
            // Loop back to first point if array ends
            if (currentPointIndex >= patrolPoints.Length)
            {
                currentPointIndex = 0;
            }
        }

        // Flip the sprite l/r
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = (transform.position.x - patrolPoints[currentPointIndex].position.x) < 0;
        }
    }
}