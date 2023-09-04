using UnityEngine;

public class EggController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initialPosition; 
    private bool isFalling = false;
    private bool isFallingRight = false;
    private bool isFallingLeft = false;
    public float fallSpeed = 1.0f;
    public float destroyAngle = 30.0f;
    [SerializeField] float currentAngle = transform.rotation.eulerAngles.x;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; 
        FallingRandomDirection();
    }
    void Update()
    {
        if (isFalling)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if ((isFallingRight && clickPosition.x > transform.position.x) ||
                    (isFallingLeft && clickPosition.x < transform.position.x))
                { 
                    ResetToInitialPosition();
                }
            }
        }
    }
    void FallingRandomDirection()
    {
        float randomXForce = Random.Range(-1f, 1f); 
        rb.AddForce(new Vector2(randomXForce, 0) * fallSpeed, ForceMode2D.Impulse); 
        isFallingRight = randomXForce > 0;
        isFallingLeft = randomXForce < 0;
        isFalling = true;
    }
    void ResetToInitialPosition()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = initialPosition; 
        FallingRandomDirection();
    }


    void destroy()
    {
        
        if (currentAngle > destroyAngle)
        {
            Destroy(gameObject);
        }
    }
    
   
}
