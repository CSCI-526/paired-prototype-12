using UnityEngine;

public class BubbleGunPlatform : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bubblePrefab;
    public KeyCode fireKey = KeyCode.Mouse0;
    public float fireSpeed = 12f;
    public float fireCooldown = 0.25f;
    public float spawnForwardOffset = 1.2f;
    private float _nextFireTime;
    private PlayerController2D player;

    void Start()
    {
        player = GetComponentInParent<PlayerController2D>();
    }


    // Update is called once per frame
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
        // Direction depends on whether the sprite is flipped
        float facing = (player != null && player.faceRight) ? 1f : -1f;
        Vector2 direction = new Vector2(facing, 0f);
        
        // spawn platform with offset
        Vector3 spawnPos = muzzle.position + (Vector3)(direction * Mathf.Abs(spawnForwardOffset));
        GameObject bubble = Instantiate(bubblePrefab, spawnPos, muzzle.rotation);

        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        rb.velocity = direction * fireSpeed;
    }
}
