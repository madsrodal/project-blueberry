using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10f;
    public float MoveSpeed = 5f;
    
    const float groundEpsilon = .2f; 
    private bool isGrounded = true;

    private Rigidbody2D rb;
    private Vector2 velocity;
    private BoxCollider2D boxCollider;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    public float WalkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    public float AirAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    public float GroundDeceleration = 70;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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

        float horizontalInput = Input.GetAxisRaw("Horizontal");   // this takes in ANY horizontal input, whether that is arrow keys, A/D or even controller input

        if (isGrounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                // Calculate the velocity required to achieve the target jump height.
                velocity.y = Mathf.Sqrt(2 * JumpForce * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = isGrounded ? WalkAcceleration : AirAcceleration;
        float deceleration = isGrounded ? GroundDeceleration : 0;
        velocity.x = Mathf.MoveTowards(velocity.x, MoveSpeed * moveInput, acceleration * Time.deltaTime);

        //if (moveInput != 0)
        //{
            

        //    transform.Translate(new Vector2(horizontalInput * Speed / 100, verticalInput * Speed / 100), Space.Self);    // translate moves an object along its transform
        //}
        //else
        //{
        //    velocity.x = 0;// Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        //    return;
        //}

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        isGrounded = false;

        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

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
