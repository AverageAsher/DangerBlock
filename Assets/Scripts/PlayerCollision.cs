using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Assign your TMP Text here in the Inspector
    private int points = 0;

    void Start()
    {
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
            points -= 30;
            
        }
        else if (other.CompareTag("DoublePoints"))
        {
            points *= 2;
            
        }

        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        pointsText.text = "Points: " + points.ToString();
    }
}
