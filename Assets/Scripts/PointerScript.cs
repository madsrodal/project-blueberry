using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // that's left mouse button
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // very cool function I like it
            mousePosition.z = 0;        // useful to zero out your Z position when working in 2D
            Debug.Log(mousePosition);   // spam stuff into console!

            // Do something cool! Shoot a projectile, spawn an explosion, up to you!

        }
    }
}
