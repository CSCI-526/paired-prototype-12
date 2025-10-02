using UnityEngine;

public class BubblePlatform : MonoBehaviour
{

    public float life = 3f;
    private Rigidbody2D rb;
    void Start()
    {
        
        
        // Cleanup after 3 seconds if nothing happens
        Destroy(gameObject, life);
    }
void OnTriggerEnter2D(Collider2D hit)
    {
        // if (!hit.CompareTag("Platform"))
        // {
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            
            rb.bodyType = RigidbodyType2D.Static;
        // }
    }
}
