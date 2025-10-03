using UnityEngine;

public class ShotBubble : MonoBehaviour
{

    public float lifetime = 3f;
    private Rigidbody2D rb;

    void Start()
    {
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
