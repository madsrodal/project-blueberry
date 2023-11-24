using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript2D : MonoBehaviour
{
    // This is intended for a Kinematic 2D player object, i.e. without gravity affecting it

    float horizontalInput;
    float verticalInput;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        // should something happen here? a mystery
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");   // this takes in ANY horizontal input, whether that is arrow keys, A/D or even controller input
        verticalInput = Input.GetAxisRaw("Vertical");       // this does the same but for vertical

        transform.Translate(new Vector2(horizontalInput * Speed / 100, verticalInput * Speed / 100), Space.Self);    // translate moves an object along its transform
    }
}
