using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    public float fallLimit = -4f;
    public float respawnHeight = 3f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Let the player visibly fall first.
        if (transform.position.y < fallLimit)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Bring the player back above the starting point.
        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + respawnHeight,
            startPosition.z
        );

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}