using UnityEngine;

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
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        isDropped = false;
        moveDirection = 0f;
    }
}
