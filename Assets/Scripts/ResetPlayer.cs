using System;
using System.Collections;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public GameObject jammer;
    public Sprite spIdle, spReset;
    public static bool IsResetting = false;
    public static int ResetCounter = 0;

    // Berrié
    private Rigidbody2D rb;
    private Tuple<Vector3, Quaternion, Vector3> rbStartTransform;
    private SpriteRenderer rbSprite;


    // Camera
    private Camera cam;
    private Vector3 camStartTransform;

    // Counter
    private Vector3 camEndTransform;
    private AudioSource resetSound;

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
        resetSound = GameObject.Find("ResetSound").GetComponent<AudioSource>();
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
        StartCoroutine(BeforeTransformCoroutine());
        StartCoroutine(TransformCoroutine());
        StartCoroutine(AfterTransformCoroutine());
    }

    public void TaskResetCamera() => cam.transform.position = camStartTransform;

    public void TaskUpdateCounter()
    {
        ResetCounter++;
    }

    private IEnumerator BeforeTransformCoroutine()
    {
        IsResetting = true;
        resetSound.Play();
        rbSprite.sprite = spReset;
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator TransformCoroutine()
    {
        yield return new WaitForFixedUpdate();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.transform.position = rbStartTransform.Item1;
        rb.transform.rotation = rbStartTransform.Item2;
        rb.transform.localScale = rbStartTransform.Item3;
    }

    private IEnumerator AfterTransformCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(jammer);
        rbSprite.sprite = spIdle;
        IsResetting = false;
    }
}
