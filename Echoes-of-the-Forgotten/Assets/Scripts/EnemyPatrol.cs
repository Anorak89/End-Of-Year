using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed = 2f;
    public float rotationSpeed = 5f;

    void Start()
    {
        targetPoint = 0;
    }

    void Update()
    {
        Vector3 targetPos = patrolPoints[targetPoint].position;
        Vector3 direction = targetPos - transform.position;

        // Rotate to face the next waypoint based on full XYZ direction
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * 100);
        }

        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // When close enough to target, move to next
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            IncreaseTargetPoint();
        }
    }

    void IncreaseTargetPoint()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
