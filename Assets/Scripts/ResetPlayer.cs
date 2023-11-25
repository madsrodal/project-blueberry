using System;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    // Berrié
    private Rigidbody2D rb;
    private Tuple<Vector3, Quaternion, Vector3> rbStartTransform;
    //private SpriteRenderer spRend;
    //private Sprite startSprite;

    // Camera
    private Camera cam;
    private Vector3 camStartTransform;

    // Counter
    private int resetCounter;

    private void Awake()
    {
        var berrie = GameObject.FindWithTag("Player");
        rb = berrie.GetComponent<Rigidbody2D>();
        rbStartTransform = new(rb.transform.position, rb.transform.rotation, rb.transform.localScale);
        //spRend = GameObject.Find("Round").GetComponent<SpriteRenderer>();
        //startSprite = spRend.sprite;

        cam = Camera.main;
        camStartTransform = cam.transform.position;

        resetCounter = 0;
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
        rb.transform.localScale = rbStartTransform.Item3;

        //Debug.Log(startSprite.texture.name);
    }

    public void TaskResetCamera() => cam.transform.position = camStartTransform;

    public void TaskUpdateCounter()
    {
        resetCounter++;
        Debug.Log($"Resets: {resetCounter}");
    }
}
