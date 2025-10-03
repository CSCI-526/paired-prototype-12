using UnityEngine;

public class Collision : MonoBehaviour
{
    public Transform playerSpawn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // sends player back to spawn point if touch enemy
            collision.gameObject.transform.position = playerSpawn.position; 
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

        }
    }

}
