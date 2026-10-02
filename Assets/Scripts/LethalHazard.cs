using UnityEngine;

public class LethalHazard : MonoBehaviour
{
    private DeathTracker deathTracker;

    void Start()
    {
        deathTracker = FindAnyObjectByType<DeathTracker>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleHit(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit(collision.gameObject);
    }

    void HandleHit(GameObject hitObject)
    {
        if (hitObject.CompareTag("Player"))
        {
            if (deathTracker != null)
            {
                deathTracker.RegisterIntentionalDeath();
            }

            // Find the player's respawn script and execute the teleport
            RespawnOnFall playerRespawn = hitObject.GetComponent<RespawnOnFall>();
            if (playerRespawn != null)
            {
                playerRespawn.ExecuteRespawn();
            }

            gameObject.SetActive(false);
        }
    }
}