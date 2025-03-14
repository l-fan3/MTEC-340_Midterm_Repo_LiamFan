using UnityEngine;

public class MBS_EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2.0f;
    public float stoppingDistance = 1.0f; // How close the enemy gets to the player
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stoppingDistance)
            {
                // Move only on the X-axis, keep Y velocity unchanged
                float moveDirection = (player.position.x > transform.position.x) ? 1 : -1;
                rb.linearVelocity = new Vector2(moveDirection * speed, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop moving when close
            }
        }
    }
}