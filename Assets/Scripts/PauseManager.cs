using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Reference to your pause menu UI
    public PlayerCollision playerCollisionScript;  // Reference to the PlayerCollision script

    void Start()
    {
        // Ensure the pause menu is inactive at the start
        pauseMenuUI.SetActive(false);
    }

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
        pauseMenuUI.SetActive(true); // Show pause menu UI
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide pause menu UI
    }

    public void OnResetPointsButton()
    {
        playerCollisionScript.ResetPoints();  // Reset points when button is clicked
        ResumeGame();  // Optionally resume the game after resetting points
    }
}
