using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    private Transform current; 
    private Rigidbody2D rb;
    public float speed; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current = Point2.transform; // set where the enemy is headed
    }
    void Update()
    {
        // calculate direction vector for enemy to current
        Vector2 direction = (current.position - transform.position).normalized;
        rb.linearVelocity = direction * speed; // move enemy 
        // check if it is close to the current
        if (Vector2.Distance(transform.position, current.position) < 0.5f)
        {
            // switch where enemy is trying to go
            if (current == Point2.transform)
            {
                current = Point1.transform;
            }
            else
            {
                current = Point2.transform;
            }
        }
    }
}
