using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject Camera;       // drag in the main camera here

    public float HorizontalThreshold;
    public float VerticalThreshold;

    public float Smoothness;    //  low value gives a choppy camera, but better performance(?) High value, and the camera might not catch up! (you can fix that?)

    Vector2 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        Camera.transform.position =  new Vector3(transform.position.x, transform.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if
            (transform.position.x > Camera.transform.position.x + HorizontalThreshold)
        {
            moveVector.x = 1;
        } else if
            (transform.position.x < Camera.transform.position.x - HorizontalThreshold)
        {
            moveVector.x = -1;
        }
        else
        {
            moveVector.x = 0;
        }

        if
    (transform.position.y > Camera.transform.position.y + VerticalThreshold)
        {
            moveVector.y = 1;
        }
        else if
            (transform.position.y < Camera.transform.position.y - VerticalThreshold)
        {
            moveVector.y = -1;
        }
        else
        {
            moveVector.y = 0;
        }

        Camera.transform.Translate(moveVector/Smoothness);
    }
}
