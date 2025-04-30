using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isDropped = false;

    private float screenLeftLimit;
    private float screenRightLimit;
    private float playerWidth;

    private Vector3 startPosition; // store starting position

    private float moveDirection = 0f; // -1 for left, 1 for right, 0 for idle

    // Reference to the FadePanel's CanvasGroup
    public CanvasGroup fadePanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        startPosition = transform.position;

        float cameraZ = Camera.main.transform.position.z;
        Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -cameraZ));
        Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, -cameraZ));

        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        screenLeftLimit = leftBound.x + playerWidth;
        screenRightLimit = rightBound.x - playerWidth;

        // Make sure the fade panel starts fully transparent
        if (fadePanel != null)
        {
            fadePanel.alpha = 0f;
        }
    }

    void Update()
    {
        if (!isDropped)
        {
            // Use button-controlled moveDirection instead of keyboard input
            Vector3 newPos = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;
            newPos.x = Mathf.Clamp(newPos.x, screenLeftLimit, screenRightLimit);
            transform.position = newPos;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Drop();
            }
        }
    }

    public void Drop()
    {
        isDropped = true;
        rb.gravityScale = 1f;
    }

    public void MoveLeft()
    {
        moveDirection = -1f;
    }

    public void MoveRight()
    {
        moveDirection = 1f;
    }

    public void StopMoving()
    {
        moveDirection = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn Player"))
        {
            ResetPlayerPosition();
        }
    }

    private void ResetPlayerPosition()
    {
        // Immediately stop all movement and physics interactions
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;  // Temporarily disable physics

        StartCoroutine(FadeAndResetPlayer());
    }

    private IEnumerator FadeAndResetPlayer()
    {
        // Fade out the screen (to black)
        if (fadePanel != null)
            yield return StartCoroutine(Fade(1f));

        // Optional delay
        yield return new WaitForSeconds(0.5f);

        // Reset position and state
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;  // Reactivate physics
        rb.gravityScale = 0f;                   // Wait until player presses Drop

        isDropped = false;
        moveDirection = 0f;

        // Fade back in (to transparent)
        if (fadePanel != null)
            yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadePanel.alpha;
        float time = 0f;
        float duration = 0.5f; // Fast fade

        while (time < duration)
        {
            time += Time.deltaTime;
            fadePanel.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        fadePanel.alpha = targetAlpha;
    }
}
