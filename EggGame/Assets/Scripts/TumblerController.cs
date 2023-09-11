using UnityEngine;
using System.Collections.Generic;

public class TumblerController : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    public float gravityScale = 1.0f; // You can modify this in the Unity Inspector
    public float delayBeforeFalling = 1.0f; // You can modify this in the Unity Inspector
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private List<TransformData> fallPath = new List<TransformData>();
    private bool isFalling = false;
    private bool isFallingRight = false;
    private bool isFallingLeft = false;
    private int replayIndex = 0;
    private bool isReplayingPath = false;
    private bool isDelayActive = false;
    private Vector2 initialMovementDirection;

    // Create a class to store position and rotation data
    [System.Serializable]
    public class TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        rb.gravityScale = gravityScale;
        FallingRandomDirection();
    }

    void Update()
    {
        if (isFalling)
        {
            if (!isReplayingPath && Input.GetMouseButtonDown(0))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if ((isFallingRight && clickPosition.x > transform.position.x) ||
                    (isFallingLeft && clickPosition.x < transform.position.x))
                {
                    StartReplayingPath();
                }
            }
            if (isReplayingPath)
            {
                if (replayIndex >= 0)
                {
                    // Retrace position and rotation
                    TransformData data = fallPath[replayIndex];
                    transform.position = data.position;
                    transform.rotation = data.rotation;
                    replayIndex--;
                }
                else
                {
                    isReplayingPath = false;
                    StartCoroutine(ResetAfterDelay(delayBeforeFalling));
                }
            }
            else if (!isDelayActive)
            {
                // Record position and rotation data
                fallPath.Add(new TransformData
                {
                    position = transform.position,
                    rotation = transform.rotation
                });
            }
        }
    }

    void FallingRandomDirection()
    {
        float randomXForce = (Random.value < 0.5f) ? -1f : 1f;
        rb.velocity = new Vector2(randomXForce, 0) * fallSpeed;
        isFallingRight = randomXForce > 0;
        isFallingLeft = randomXForce < 0;
        isFalling = true;

        // Store the initial movement direction
        initialMovementDirection = rb.velocity.normalized;
    }

    void StartReplayingPath()
    {
        isReplayingPath = true;
        replayIndex = fallPath.Count - 2;
    }

    System.Collections.IEnumerator ResetAfterDelay(float delay)
    {
        isDelayActive = true;
        rb.simulated = false;
        yield return new WaitForSeconds(delay);
        rb.simulated = true;
        isDelayActive = false;
        ResetToInitialPosition();
    }

    void ResetToInitialPosition()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Reset the position to the initial position
        transform.position = initialPosition;

        // Reset the rotation to zero
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Clear the fall path
        fallPath.Clear();

        // Reapply the initial movement direction in reverse
        FallingRandomDirection();

        isFalling = true;
    }
}