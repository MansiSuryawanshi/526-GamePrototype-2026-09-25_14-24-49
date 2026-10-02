using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [Tooltip("Events to fire when the player touches this object.")]
    public UnityEvent onPlayerEnter;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            onPlayerEnter.Invoke();
        }
    }
}