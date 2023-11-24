using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPosition;

    private void Awake()
    {
        rb = GameObject.Find("Berrié").GetComponent<Rigidbody2D>();
        startPosition = rb.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TaskResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.MovePosition(startPosition);
        rb.MoveRotation(0);
    }
}
