using UnityEngine;
using UnityEngine.UI;

public class DeathTracker : MonoBehaviour
{
    [Tooltip("Drag the 3 UI Heart Images here in order (Left to Right)")]
    public Image[] hearts;

    private int remainingTargets;

    void Start()
    {
        // Set the target number of deaths based on the number of hearts assigned
        remainingTargets = hearts.Length;
    }

    public void RegisterIntentionalDeath()
    {
        if (remainingTargets > 0)
        {
            remainingTargets--;

            // "Blow out" the heart by turning it black (or use .enabled = false to hide it completely)
            hearts[remainingTargets].color = Color.black;
        }

        if (remainingTargets <= 0)
        {
            TriggerLevelComplete();
        }
    }

    void TriggerLevelComplete()
    {
        // Replace with your actual level loading or win screen logic
        Debug.Log("All traps triggered! Level Cleared!");
    }
}