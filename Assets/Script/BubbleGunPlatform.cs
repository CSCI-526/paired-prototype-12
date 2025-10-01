using UnityEngine;

public class BubbleGunPlatform : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bubblePrefab;
    public KeyCode fireKey = KeyCode.Mouse0;
    public float fireSpeed = 12f;
    public float fireCooldown = 0.25f;
    public float spawnForwardOffset = 0.5f;
    private float _nextFireTime;


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
        Vector3 spawnPos = muzzle.position + (Vector3)(muzzle.right * spawnForwardOffset);
        GameObject bubble = Instantiate(bubblePrefab, spawnPos, muzzle.rotation);

        bubble.GetComponent<Rigidbody2D>().velocity = muzzle.right * fireSpeed;
    }
}
