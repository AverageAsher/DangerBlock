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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        startPosition = transform.position; // save initial position

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
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 newPos = transform.position + Vector3.right * moveInput * moveSpeed * Time.deltaTime;

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
    }
}
