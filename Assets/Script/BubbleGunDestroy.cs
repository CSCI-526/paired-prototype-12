using UnityEngine;

public class BubbleGunDestroy : MonoBehaviour
{
    public Transform muzzle; // bubble shoots from muzzle
    public GameObject destroyBubblePrefab; // prefab of destroying bubble                   
    public KeyCode fireKey = KeyCode.Mouse1; // right click shoots these bubbles
    public float fireSpeed = 12f;
    public float fireCooldown = 0.25f;
    public float bubbleLifetime = 3f;
    public float spawnForwardOffset = 0.1f;
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
        Debug.Log("Fired bubble");
        if (!destroyBubblePrefab) return;
       
        // spawn bubble from muzzle
        Vector3 spawnPos = muzzle.position + (Vector3)(muzzle.right * spawnForwardOffset);
        GameObject bubble = Instantiate(destroyBubblePrefab, spawnPos, muzzle.rotation);

        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = muzzle.right * fireSpeed; // for velocity of fired bubble
        }
        Destroy(bubble, bubbleLifetime); //destroy bubble after lifetime of bubble
    }
}
