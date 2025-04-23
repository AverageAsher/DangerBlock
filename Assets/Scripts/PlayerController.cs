using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public RectTransform movementBounds; // Assign the UI panel or canvas RectTransform

    private Rigidbody2D rb;
    private RectTransform rectTransform;
    private Vector2 movement;
    private float halfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();

        // Gravity disabled until space is pressed
        rb.gravityScale = 0f;

        // Calculate half-width for edge clamping
        CircleCollider2D col = GetComponent<CircleCollider2D>();
        halfWidth = col != null ? col.radius * transform.localScale.x : 0.5f;
    }

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        movement = new Vector2(moveX, rb.linearVelocity.y);

        // Enable gravity on drop
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = 1f; // Only gravity from Rigidbody2D is used now
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Clamp horizontal position inside RectTransform bounds
        Vector3[] corners = new Vector3[4];
        movementBounds.GetWorldCorners(corners); // BL, TL, TR, BR

        Vector3 pos = rectTransform.position;
        float playerWidth = rectTransform.rect.width * rectTransform.lossyScale.x / 2f;

        pos.x = Mathf.Clamp(pos.x, corners[0].x + playerWidth, corners[2].x - playerWidth);
        rectTransform.position = pos;
    }
}
