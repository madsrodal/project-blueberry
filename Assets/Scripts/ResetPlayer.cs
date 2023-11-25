using System;
using System.Collections;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Sprite spIdle, spReset;
    public bool IsResetting = false;

    // Berrié
    private Rigidbody2D rb;
    private Tuple<Vector3, Quaternion, Vector3> rbStartTransform;
    private SpriteRenderer rbSprite;

    // Jam
    //private TrailRenderer gooTrail;

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
        rbSprite = berrie.GetComponentInChildren<SpriteRenderer>();

        //var playerGoo = GameObject.FindWithTag("PlayerGoo");
        //gooTrail = playerGoo.GetComponent<TrailRenderer>();

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
        //StartCoroutine(Gooey(false));

        rbSprite.sprite = spReset;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.transform.position = rbStartTransform.Item1;
        rb.transform.rotation = rbStartTransform.Item2;
        rb.transform.localScale = rbStartTransform.Item3;

        //EnableGoo();
        StartCoroutine(SpriteDelayCoroutine());
    }

    public void TaskResetCamera() => cam.transform.position = camStartTransform;

    public void TaskUpdateCounter()
    {
        resetCounter++;
        Debug.Log($"Resets: {resetCounter}");
    }

    //private IEnumerator Gooey(bool enabled)
    //{
    //    gooTrail.emitting = enabled;
    //    yield return new WaitForFixedUpdate();
    //}

    private IEnumerator SpriteDelayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        rbSprite.sprite = spIdle;
    }
}
