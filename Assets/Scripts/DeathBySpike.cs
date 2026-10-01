using UnityEngine;

public class DeathBySpike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DIED TO SPIKES");
        }
    }
}