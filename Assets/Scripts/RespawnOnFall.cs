using UnityEngine;
using UnityEngine.Events;

public class RespawnOnFall : MonoBehaviour
{
    [Tooltip("How far the player can fall from their peak height before dying.")]
    public float maxFallDistance = 10f;
    public float respawnHeight = 3f;

    [Header("Level Events")]
    [Tooltip("Triggered ONLY the very first time the player dies by falling.")]
    public UnityEvent onFirstFallDeath;

    [Tooltip("Triggered EVERY time the player respawns.")]
    public UnityEvent onEveryRespawn;

    private Vector3 startPosition;
    private Rigidbody2D rb;
    private float peakHeight;

    private DeathTracker deathTracker;
    private bool hasFallenDeathCounted = false;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        peakHeight = transform.position.y;

        deathTracker = FindAnyObjectByType<DeathTracker>();
    }

    void Update()
    {
        if (rb.linearVelocity.y >= -0.1f)
        {
            peakHeight = transform.position.y;
        }

        float currentFallDistance = peakHeight - transform.position.y;

        if (currentFallDistance >= maxFallDistance)
        {
            HandleFallDeath();
        }
    }

    // This is called by Update() when the player falls too far
    void HandleFallDeath()
    {
        if (!hasFallenDeathCounted)
        {
            if (deathTracker != null)
            {
                deathTracker.RegisterIntentionalDeath();
            }

            onFirstFallDeath.Invoke();
            hasFallenDeathCounted = true;
        }

        // Do the actual physical teleport
        ExecuteRespawn();
    }

    // This is public, so any trap in the game can call it to teleport the player
    public void ExecuteRespawn()
    {
        onEveryRespawn.Invoke();

        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + respawnHeight,
            startPosition.z
        );

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        peakHeight = transform.position.y;
    }
}