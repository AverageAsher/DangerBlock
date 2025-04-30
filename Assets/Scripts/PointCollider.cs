using UnityEngine;

public class PointCollider : MonoBehaviour
{
    public enum PointType { Positive, Negative }
    public PointType pointType;

    public AudioClip positiveClip;
    public AudioClip negativeClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Optionally check if the player/ball is what collided
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayPointSound();
        }
    }

    void PlayPointSound()
    {
        if (AudioManager.Instance == null) return;

        switch (pointType)
        {
            case PointType.Positive:
                AudioManager.Instance.PlaySound(positiveClip);
                break;
            case PointType.Negative:
                AudioManager.Instance.PlaySound(negativeClip);
                break;
        }
    }
}
