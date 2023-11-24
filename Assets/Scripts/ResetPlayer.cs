using System;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    // Berri�
    private Rigidbody2D rb;
    private Tuple<Vector3, Quaternion> rbStartTransform;

    // Camera
    private Camera cam;
    private Vector3 camStartTransform;

    private void Awake()
    {
        rb = GameObject.Find("Berri�").GetComponent<Rigidbody2D>();
        rbStartTransform = new Tuple<Vector3, Quaternion>(rb.transform.position, rb.transform.rotation);

        cam = Camera.main;
        camStartTransform = cam.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TaskResetTransform()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.transform.position = rbStartTransform.Item1;
        rb.transform.rotation = rbStartTransform.Item2;
    }

    public void TaskResetCamera()
    {
        cam.transform.position = camStartTransform;
    }
}
