using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float JumpForce = 5f;
    public float MoveSpeed = 400f;
    
    const float groundEpsilon = .2f; 
    private bool isGrounded = true;

    private Rigidbody2D rb;
    public Vector2 velocity;
    private CircleCollider2D circleCollider;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    public float WalkAcceleration = 300;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    public float AirAcceleration = 150;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    public float GroundDeceleration = 300;
    public bool jumping = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        jumping = Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0;

        float acceleration = isGrounded ? WalkAcceleration : AirAcceleration;
        velocity.x = Mathf.MoveTowards(velocity.x, MoveSpeed * moveInput, acceleration);
        rb.AddForce(velocity * Time.deltaTime);

        if (isGrounded)
        {
            velocity.y = 0;

            if (jumping)
            {
                // Calculate the velocity required to achieve the target jump height.
                velocity.y = Mathf.Sqrt(2 * JumpForce * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        rb.AddForce(new Vector2(0, velocity.y), ForceMode2D.Impulse);
        
        isGrounded = false;

        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, circleCollider.radius + groundEpsilon);

        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == circleCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(circleCollider);

            // Ensure that we are still overlapping this collider.
            // The overlap may no longer exist due to another intersected collider
            // pushing us out of this one.
            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If we intersect an object beneath us, set grounded to true. 
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    isGrounded = true;
                }
            }
        }
    }
}
