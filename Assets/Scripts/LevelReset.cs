using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading and reloading scenes

public class LevelReset : MonoBehaviour
{
    void Update()
    {
        // Listen for the R key to be pressed down
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload the currently active scene by getting its name
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}