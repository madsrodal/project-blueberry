using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGravityScript2D : MonoBehaviour
{
    // This is intended for a 2D player object affected by gravity. Move from side to side and press space to jump

    float horizontalInput;
    //float verticalInput;

    Rigidbody2D rb;

    public float Speed;
    public int JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");   // this takes in ANY horizontal input, whether that is arrow keys, A/D or even controller input
        //verticalInput = Input.GetAxisRaw("Vertical");     // this does the same but for vertical - disabled for this controller. re-enable it if you find it useful

        transform.Translate(new Vector2(horizontalInput * Speed / 100, 0), Space.Self);    // translate moves an object along its transform

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(transform.up * JumpForce);
        }
    }
    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f); // if you change the size/position of the player character, you MUST change the 0.8f so you hit the ground
    }
}
