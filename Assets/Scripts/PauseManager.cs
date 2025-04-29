using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

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
}
