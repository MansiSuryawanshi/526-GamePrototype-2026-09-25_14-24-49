using UnityEngine;

public class TrapReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        // Remember the initial location when the game starts
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // This public method will be triggered by the Player
    public void ResetPosition()
    {
        // Only reset it if the trap hasn't been permanently consumed by the player dying to it
        if (gameObject.activeSelf)
        {
            transform.position = startPosition;

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}