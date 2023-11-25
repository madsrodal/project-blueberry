using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{


    public GameObject Camera;       // drag in the main camera here

    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;

    void FixedUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(Camera.transform.position, transform.position + locationOffset, smoothSpeed);
        Camera.transform.position = smoothedPosition;

    }
}
