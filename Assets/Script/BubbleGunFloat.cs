using UnityEngine;

// Attach  to: Gun (NOT Player/ PlayerGun)
public class BubbleGun : MonoBehaviour
{
    
    public Transform muzzle;
    public GameObject bubblePrefab;
    public KeyCode fireKey = KeyCode.Mouse0;
    public float fireSpeed = 12f;
    public float fireCooldown = 0.25f;
    public float bubbleLifetime = 3f;
    public float spawnForwardOffset = 0.1f;

    public Collider2D playerColliderToIgnore;

    private float _nextFireTime;

    void Update()
    {
        if (Input.GetKey(fireKey) && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + fireCooldown;
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 spawnPos = muzzle.position + (Vector3)(muzzle.right * spawnForwardOffset);
        GameObject bubble = Instantiate(bubblePrefab, spawnPos, muzzle.rotation);

        bubble.GetComponent<Rigidbody2D>().linearVelocity = muzzle.right * fireSpeed;

        if (playerColliderToIgnore != null)
        {
            Physics2D.IgnoreCollision(bubble.GetComponent<Collider2D>(), playerColliderToIgnore, true);
        }

        Destroy(bubble, bubbleLifetime);
    }
}