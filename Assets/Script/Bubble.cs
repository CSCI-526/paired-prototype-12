using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float size = 2f;
    public float extraTime = 0.1f;

    private Rigidbody2D rb;
    private Collider2D trigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trigger = GetComponent<Collider2D>();
        
        // Cleanup after 3 seconds if nothing happens
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (!hit.CompareTag("Platform")) return;

        PlatformBehavior platform = hit.GetComponent<PlatformBehavior>();
        if (!platform) return;

        // Stop bubble movement
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        trigger.enabled = false;

        // Activate platform
        float totalTime = platform.riseTime+platform.stayTime;
        platform.RiseForSeconds(platform.stayTime);

        // Move to platform center and scale bubble to fit
        transform.position = hit.bounds.center;
        float platformSize = hit.bounds.size.x;
        float bubbleScale = Mathf.Max(platformSize+0.5f, size);
        transform.localScale = Vector3.one*bubbleScale;
        
        // Stick to platform
        transform.SetParent(hit.transform);

        // Clean up when platform is done
        // not so good, don't know why
        Destroy(gameObject, totalTime + extraTime);
    }
}