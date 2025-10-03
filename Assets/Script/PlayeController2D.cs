using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // move
    public float speed = 8f;
    public float accel = 60f;
    public float decel = 70f;
    public float airCtrl = 0.6f;

    // jump
    public float jumpForce = 12f;

    // gravity
    public float gravity = 3f;
    public float fallMulti = 2f;
    public float shortHop = 3f;
    public float maxFall = -20f;

    // ground
    public Transform groundCheck;
    public float checkR = 0.15f;
    public LayerMask groundMask;

    // sprite + gun
    public SpriteRenderer sr;
    public Transform gun;

    // respawn
    public Transform respawnPoint;  
    public float fallThreshold = -10f;
    Rigidbody2D rb;
    float h;
    bool grounded;
    public bool faceRight = true;
    Vector3 gunStart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!sr) sr = GetComponentInChildren<SpriteRenderer>();

        rb.gravityScale = gravity;

        if (gun) gunStart = gun.localPosition;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkR, groundMask);

        // jump
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // gravity
        if (rb.linearVelocity.y < 0)
            rb.gravityScale = gravity * fallMulti;
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = gravity * shortHop;
        else
            rb.gravityScale = gravity;

        if (rb.linearVelocity.y < maxFall)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxFall);

        // flip
        if (h > 0) faceRight = true;
        if (h < 0) faceRight = false;

        if (sr) sr.flipX = !faceRight;

        // gun
        if (gun)
        {
            Vector3 pos = gunStart;
            pos.x = faceRight ? Mathf.Abs(pos.x) : -Mathf.Abs(pos.x);
            gun.localPosition = pos;
            gun.localRotation = faceRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        }

        // respawn check
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        float target = h * speed;
        float cur = rb.linearVelocity.x;

        float a = Mathf.Abs(target) > 0.01f ? accel : decel;
        if (!grounded) a *= airCtrl;

        float newSpd = Mathf.MoveTowards(cur, target, a * Time.fixedDeltaTime);
        rb.velocity = new Vector2(newSpd, rb.velocity.y);
    }

    void Respawn()
    {
        
            transform.position = respawnPoint.position;
       

       
    }

    void OnDrawGizmosSelected()
    {
        if (!groundCheck) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkR);
    }
}
