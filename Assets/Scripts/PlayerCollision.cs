using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Assign your TMP Text here in the Inspector
    private int points = 0;
    private int currentLevel;

    void Start()
    {
        currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;  // Get the current scene index (level)
        LoadPoints();  // Load points when the game starts
        UpdatePointsText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag("AddPoints"))
        {
            points += 10;
        }
        else if (other.CompareTag("TakePoints"))
        {
            points -= 50;
        }
        else if (other.CompareTag("DoublePoints"))
        {
            points += 100;
        }
        else if (other.CompareTag("ZeroPoints"))
        {
            points = 0;
        }

        SavePoints();  // Save points after any change
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        pointsText.text = "Points: " + points.ToString();
    }

    // Save points to PlayerPrefs for the current level
    void SavePoints()
    {
        PlayerPrefs.SetInt("Level" + currentLevel + "Points", points);
        PlayerPrefs.Save();
    }

    // Load points from PlayerPrefs for the current level
    void LoadPoints()
    {
        points = PlayerPrefs.GetInt("Level" + currentLevel + "Points", 0);  // Default to 0 if no saved data exists
    }

    // Reset points for the current level
    public void ResetPoints()
    {
        points = 0;
        SavePoints();  // Save the reset points
        UpdatePointsText();
    }
}
