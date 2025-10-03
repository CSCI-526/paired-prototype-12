using UnityEngine;

public class ShotBubble : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public Vector2 direction = Vector2.right;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;
        Destroy(gameObject, lifetime); // destroy bubble after lifetime
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // if collides with enemy
        {
            Destroy(other.gameObject); // destroy enemy and bubble
            Destroy(gameObject);
        }
    }
}
