using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public PlayerCollision playerCollisionScript; // Reference to PlayerCollision script

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Freeze time
        isPaused = true;
        // Optionally: Show pause UI
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        // Optionally: Hide pause UI
    }

    // Reset points for the current level
    public void OnResetPointsButton()
    {
        playerCollisionScript.ResetPoints(); // Call ResetPoints from PlayerCollision
    }
}
