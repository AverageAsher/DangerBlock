using UnityEngine;

public class MoveLeftRightBounce : MonoBehaviour
{
    public float speed = 2f;                // Horizontal speed
    public float bounceHeight = 0.5f;       // How high it bounces
    public float bounceSpeed = 2f;          // How fast it bounces up/down

    private float direction = 1f;
    private float halfWidth;
    private float startY;

    void Start()
    {
        // Store the original Y position to bounce around it
        startY = transform.position.y;

        // Get half width of the sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            halfWidth = sr.bounds.extents.x;
        }
    }

    void Update()
    {
        // Move horizontally
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Bounce vertically using sine wave
        float newY = startY + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Clamp within camera bounds
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfWidth;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfWidth;

        // Edge detection and snapping fix
        if (transform.position.x <= screenLeft)
        {
            direction = 1f;
            transform.position = new Vector3(screenLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= screenRight)
        {
            direction = -1f;
            transform.position = new Vector3(screenRight, transform.position.y, transform.position.z);
        }
    }
}
