using UnityEngine;
using System.Collections.Generic;

public class TumblerController : MonoBehaviour
{
    public float fallSpeed = 1.0f; 
    public float gravityScale = 1.0f; 
    public float delayBeforeFalling = 1.0f; 
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private List<Vector2> fallPath = new List<Vector2>();
    private bool isFalling = false;
    private bool isFallingRight = false;
    private bool isFallingLeft = false;
    private int replayIndex = 0;
    private bool isReplayingPath = false;
    private bool isDelayActive = false; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale; 
        initialPosition = transform.position;
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
                    transform.position = fallPath[replayIndex];
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
                
                fallPath.Add(transform.position);
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
        transform.position = initialPosition;
        fallPath.Clear(); 
        FallingRandomDirection();
        isFalling = true; 
    }
}
