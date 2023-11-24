using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public Vector3 velocity;
    public float fireballSpeed = 20;    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        velocity = transform.forward * fireballSpeed * Time.deltaTime;
        transform.Translate(velocity);        
    }
}
